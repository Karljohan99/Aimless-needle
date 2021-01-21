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
        if (cooldown < Time.time && collision.CompareTag("Player") && pickaxe != null && Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObject);
            pickaxe.GetComponent<AudioSource>().Play();
            switch (currentSize) 
            {
                case 1:
                    GameObject rock2 = Instantiate(Rock2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    rock2.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    GameObject smallRock11 = Instantiate(SmallRock, new Vector3(transform.position.x - 0.8f, transform.position.y + 0.8f, transform.position.z), Quaternion.identity);
                    smallRock11.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    GameObject smallRock12 = Instantiate(SmallRock, new Vector3(transform.position.x + 0.8f, transform.position.y + 1f, transform.position.z), Quaternion.identity);
                    smallRock12.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    GameObject smallRock13 = Instantiate(SmallRock, new Vector3(transform.position.x + 1.2f, transform.position.y - 0.8f, transform.position.z), Quaternion.identity);
                    smallRock13.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    GameObject smallRock14 = Instantiate(SmallRock, new Vector3(transform.position.x - 1.2f, transform.position.y - 0.8f, transform.position.z), Quaternion.identity);
                    smallRock14.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    break;
                case 2:
                    GameObject rock3 = Instantiate(Rock3, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    rock3.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    GameObject smallRock21 = Instantiate(SmallRock, new Vector3(transform.position.x - 0.6f, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                    smallRock21.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    GameObject smallRock22 = Instantiate(SmallRock, new Vector3(transform.position.x + 0.7f, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    smallRock22.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    GameObject smallRock23 = Instantiate(SmallRock, new Vector3(transform.position.x - 0.7f, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    smallRock23.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    break;
                case 3:
                    GameObject smallRock31 = Instantiate(SmallRock, new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
                    smallRock31.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    GameObject smallRock32 = Instantiate(SmallRock, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    smallRock32.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    GameObject smallRock33 = Instantiate(SmallRock, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
                    smallRock33.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    break;
            }
            
            
        }
    }

    private InventoryButton isPickaxeSelected()
    {
        foreach (Slot slot in inventory.slots)
        {
            if (slot.isSelected && (slot.tag == "Stone Pickaxe" || slot.tag == "Steel Pickaxe" || slot.tag == "Blue Pickaxe" || slot.tag == "Rose Pickaxe")) return slot.transform.GetChild(1).GetComponent<InventoryButton>();
        }
        return null;
    }
}
