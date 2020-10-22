using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public TextMeshProUGUI countText;
    public Sprite imageSelected;
    public Sprite imageUnselected;

    public bool isSelected = false;
    

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
       if (transform.childCount <=1)
        {
            inventory.isFull[i] = false;
            inventory.slots[i].tag = "Untagged";
        }
        countText.text = inventory.count[i].ToString();
        if (inventory.count[i] < 1) countText.enabled = false;
        else countText.enabled = true;
       
        if (Input.GetKeyDown(KeyCode.E) && isSelected)
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        Interactable dropItem = gameObject.transform.GetChild(1).GetComponent<InventoryButton>().dropItem;
        dropItem.GetComponent<SpriteRenderer>().sortingLayerName = "Behind player";
        Instantiate(dropItem, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
        
        inventory.count[i] -= 1;
        if (inventory.count[i] < 1)
        {
            Destroy(gameObject.transform.GetChild(1).gameObject);
            UnselectItem();
        }
    }

    public void SelectItem()
    {
        isSelected = true;
        gameObject.GetComponent<Image>().sprite = imageSelected;
    }

    public void UnselectItem()
    {
        isSelected = false;
        gameObject.GetComponent<Image>().sprite = imageUnselected;
    }

    public void SetCount(int count)
    {
        countText.text = count.ToString();
    }

}
