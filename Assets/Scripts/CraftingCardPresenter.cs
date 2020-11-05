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
        //print(checkItemCount(tags));
        CraftButton.enabled = inventory.isFull.Contains(false) && checkItemCount() && checkTargetItem();
        //print(ingedientTags.SetEquals(tags));
        
    }

    private bool checkItemCount()
    {
        foreach (CraftingIngredientData ingredient in Data.Panels[index].Ingredients)
        {
            int i = tags.IndexOf(ingredient.Item.Tag);
            if (i < 0) return false;
            if (inventory.count[i] < ingredient.Amount) return false;

        }
        return true;
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
        print("Craft");
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
