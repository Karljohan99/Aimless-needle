using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject Rock2;
    public GameObject Rock3;
    public GameObject SmallRock;
    public int currentSize;

    private Inventory inventory;
    private float cooldown;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        cooldown = Time.time + 1; 
    }


    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        InventoryButton pickaxe = isPickaxeSelected();
        if (cooldown < Time.time && collision.CompareTag("Player") && pickaxe != null && Input.GetKey(KeyCode.R))
        {
            Destroy(gameObject);
            pickaxe.GetComponent<AudioSource>().Play();
            switch (currentSize) 
            {
                case 1:
                    Instantiate(Rock2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(SmallRock, new Vector3(transform.position.x - 0.8f, transform.position.y + 0.8f, transform.position.z), Quaternion.identity);
                    Instantiate(SmallRock, new Vector3(transform.position.x + 0.8f, transform.position.y + 1f, transform.position.z), Quaternion.identity);
                    Instantiate(SmallRock, new Vector3(transform.position.x + 1.2f, transform.position.y - 0.8f, transform.position.z), Quaternion.identity);
                    Instantiate(SmallRock, new Vector3(transform.position.x - 1.2f, transform.position.y - 0.8f, transform.position.z), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Rock3, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(SmallRock, new Vector3(transform.position.x - 0.6f, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    Instantiate(SmallRock, new Vector3(transform.position.x + 0.7f, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    Instantiate(SmallRock, new Vector3(transform.position.x - 0.7f, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(SmallRock, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
                    Instantiate(SmallRock, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    Instantiate(SmallRock, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    break;
            }
            
            
        }
    }

    private InventoryButton isPickaxeSelected()
    {
        foreach (Slot slot in inventory.slots)
        {
            if (slot.isSelected && slot.tag == "Stone Pickaxe") return slot.transform.GetChild(1).GetComponent<InventoryButton>();
        }
        return null;
    }
}
