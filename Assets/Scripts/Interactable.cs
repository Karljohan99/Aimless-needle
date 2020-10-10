using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public int maxStack;
    

    void Start()
    {

    }


    void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int slot = IsStackable();
            if (slot != -1 && Input.GetKey(KeyCode.Q))
            {
                Destroy(gameObject);
                inventory.count[slot] += 1;
            }
            else {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (!inventory.isFull[i])
                    {
                        if (Input.GetKey(KeyCode.Q))
                        {
                            inventory.isFull[i] = true;
                            Instantiate(itemButton, inventory.slots[i].transform, false);
                            Destroy(gameObject);
                            inventory.slots[i].tag = gameObject.tag;
                            itemButton.tag = gameObject.tag;
                            inventory.count[i] += 1;
                            
                        }
                        break;
                    }
                }
            }
        }
    }

    public int IsStackable()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].CompareTag(gameObject.tag) == true && maxStack > inventory.count[i])
            {
                return i;
            }
        }
        return -1;
    }

   
}
