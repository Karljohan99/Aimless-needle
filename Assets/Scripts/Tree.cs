using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject dropItem;
    private Inventory inventory;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isAxeSelected() && Input.GetKey(KeyCode.R))
        {
            Destroy(gameObject);
            Instantiate(dropItem, transform.position, Quaternion.identity);
            
        }
    }

    private bool isAxeSelected()
    {
        foreach (Slot slot in inventory.slots)
        {
            if (slot.isSelected && slot.tag == "Stone Axe") return true;
        }
        return false;
    }
}
