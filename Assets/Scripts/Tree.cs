using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject dropItem;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        InventoryButton axe = isAxeSelected();
        if (collision.CompareTag("Player") && axe != null && Input.GetKey(KeyCode.R))
        {
            Destroy(gameObject);
            axe.GetComponent<AudioSource>().Play();
            GameObject item = Instantiate(dropItem, transform.position, Quaternion.identity);
            item.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
        }
    }

    private InventoryButton isAxeSelected()
    {
        foreach (Slot slot in inventory.slots)
        {
            if (slot.isSelected && slot.tag == "Stone Axe") return slot.transform.GetChild(1).GetComponent<InventoryButton>();
        }
        return null;
    }
}
