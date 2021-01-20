using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CraftingCardPresenter : MonoBehaviour
{

    public CraftingTableData Data;
    public Image TargetItemImage;
    public Button CraftButton;
    public Button NextButton;
    public Button PreviousButton;
    public GameObject ItemCardPanel;
    public ItemCardPresenter ItemCardPresenter;
    public int index;

    private Inventory inventory;
    private HashSet<string> ingedientTags = new HashSet<string>();
    List<string> tags;
    //private bool buttonActive = false;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        TargetItemImage.GetComponent<Image>().sprite = Data.Panels[index].TargetItem.Sprite;
        CraftButton.onClick.AddListener(CraftItem);
        NextButton.onClick.AddListener(NextPanel);
        PreviousButton.onClick.AddListener(PreviousPanel);
        ingedientTags.Add("Untagged");

        foreach (CraftingIngredientData ingredient in Data.Panels[index].Ingredients) 
        {
            ingedientTags.Add(ingredient.Item.Tag);
            ItemCardPresenter.ItemData = ingredient.Item;
            ItemCardPresenter.Amount = ingredient.Amount;
            ItemCardPresenter itemCard = Instantiate(ItemCardPresenter);
            itemCard.transform.SetParent(ItemCardPanel.transform);
            itemCard.transform.localScale = new Vector3(1,1,1);
        }
    }

    void Update()
    {
        tags = new List<string>();
        foreach (Slot slot in inventory.slots) 
        {
            tags.Add(slot.tag);
        }
        CraftButton.enabled = inventory.isFull.Contains(false) && checkItemCount() && checkTargetItem();
        if (!CraftButton.isActiveAndEnabled && CraftButton.transform.GetChild(0).GetComponent<Image>().color != Color.gray) 
        {
            Color color = CraftButton.GetComponent<Image>().color;
            color.a = 0;
            CraftButton.GetComponent<Image>().color = color;
            CraftButton.transform.GetChild(0).GetComponent<Image>().color = Color.gray;
        } 
        if (CraftButton.isActiveAndEnabled && CraftButton.transform.GetChild(0).GetComponent<Image>().color != Color.white)
        {
            Color color = CraftButton.GetComponent<Image>().color;
            color.a = 0.5f;
            CraftButton.GetComponent<Image>().color = color;
            CraftButton.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
    }

    private bool checkItemCount()
    {
        bool check = true;
        for (int j = 0; j < Data.Panels[index].Ingredients.Length; j++) 
        {
            bool itemCheck = true;
            CraftingIngredientData ingredient = Data.Panels[index].Ingredients[j];
            int i = tags.IndexOf(ingredient.Item.Tag);
            if (i < 0) 
            {
                ItemCardPanel.transform.GetChild(j).GetComponent<Image>().color = Color.red;
                itemCheck = false;
                check = false;
                continue;
            }
            if (inventory.count[i] < ingredient.Amount) 
            {
                ItemCardPanel.transform.GetChild(j).GetComponent<Image>().color = Color.red;
                itemCheck = false;
                check = false;
                continue;
            }
            ItemCardPanel.transform.GetChild(j).GetComponent<Image>().color = Color.white;
        }
        return check;
    }

    private bool checkTargetItem()
    {
        int i = tags.IndexOf(Data.Panels[index].TargetItem.Tag);
        if (i >= 0) 
        {
            if (inventory.count[i] >= Data.Panels[index].TargetItem.MaxStack) return false;
        }
        return true;
    }


    public void CraftItem()
    {
        GetComponent<AudioSource>().Play();
        foreach (CraftingIngredientData ingredient in Data.Panels[index].Ingredients) 
        {
            int i = tags.IndexOf(ingredient.Item.Tag);
            if (i < 0) return;
            for (int j=0; j < ingredient.Amount; j++) 
            {
                Events.RemoveItem(i);
            }
        }

        int slot = IsStackable();

        if (slot >= 0)
        {
            inventory.count[slot] += 1;
        }
        else if (slot == -1) {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    inventory.isFull[i] = true;
                    Instantiate(Data.Panels[index].TargetItem.ItemButton, inventory.slots[i].transform, false);
                    inventory.slots[i].tag = Data.Panels[index].TargetItem.Tag;
                    inventory.count[i] += 1;
                    break;
                }
            }
        }
    }

    private int IsStackable()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].CompareTag(Data.Panels[index].TargetItem.Tag) == true)
            {
                return i;
            }
        }
        return -1;
    }

    public void NextPanel()
    {
        Events.NextCraftingCard();
    }

    public void PreviousPanel()
    {
        Events.PreviousCraftingCard();
    }
}
