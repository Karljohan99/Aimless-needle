using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public GameObject dropItem;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(SelectSlot);
    }

    void Update()
    {
        
    }

    public void SelectSlot()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].CompareTag(gameObject.tag) == true)
            {
                inventory.slots[i].GetComponent<Slot>().SelectItem();
            }
            else
            {
                if (inventory.slots[i].GetComponent<Slot>().isSelected) inventory.slots[i].GetComponent<Slot>().UnselectItem();
            }
        }
    }
}
