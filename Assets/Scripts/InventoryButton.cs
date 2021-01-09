using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public Interactable dropItem;
    private Inventory inventory;
    private Button button;
    private int index = -1;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(SelectSlot);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 0;
            button.onClick.Invoke();
            index = -1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
            button.onClick.Invoke();
            index = -1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 2;
            button.onClick.Invoke();
            index = -1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 3;
            button.onClick.Invoke();
            index = -1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            index = 4;
            button.onClick.Invoke();
            index = -1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            index = 5;
            button.onClick.Invoke();
            index = -1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            index = 6;
            button.onClick.Invoke();
            index = -1;
        }
    }

    public void SelectSlot()
    {
        bool c = false;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].CompareTag(gameObject.tag) == true && (index == -1 || index == i)) 
            {
                c = true;
                break;
            } 
        }
        if (!c) return;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].CompareTag(gameObject.tag) == true && (index == -1 || index == i))
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
