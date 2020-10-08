using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Interactable : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;


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
            for (int i=0; i<inventory.slots.Length; i++)
            {

                if (inventory.isFull[i] ==false)
                {
                    if (Input.GetKey(KeyCode.Q))
                    {                     
                        inventory.isFull[i] = true;
                        Instantiate(itemButton, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                    }
                    break;
                }
            }


          
        }
    }

    public bool IsStackable()
    {
        if (itemButton.CompareTag(gameObject.tag)==true)
        {
            return true;
        }
        return false;
    }
}
