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
    public float damage = 0;
    public float cooldown = 1;
    

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Inventory>();
    }


    void Update()
    {
        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int slot = IsStackable();
            if (slot >= 0 && Input.GetKey(KeyCode.Q))
            {
                Destroy(gameObject);
                inventory.count[slot] += 1;
            }
            else if (slot == -1) {
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
            if (inventory.slots[i].CompareTag(gameObject.tag) == true)
            {
                if (maxStack > inventory.count[i]) return i;
                else return -2;
                
            }
        }
        return -1;
    }

   
}
