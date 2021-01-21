using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showel : MonoBehaviour
{
    public GameObject Dirt;

    public DiggingProbabilityData Data;

    public float cooldown = 1;

    private Inventory inventory;

    private bool canDig = true;

    private float nextTime;

    private float checkDelay = 0.5f;

    private float nextCheckTime;

    private void Awake()
    {            
        Events.OnSetDig += SetDig;
        nextTime = Time.time;
        nextCheckTime = Time.time;
    }

    private void OnDestroy()
    {
        Events.OnSetDig -= SetDig;
    }

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if (nextCheckTime < Time.time) 
        {
            canDig = true;
            nextCheckTime = Time.time + checkDelay;
        }
        if (nextTime < Time.time && canDig && isShovelSelected() && Input.GetKeyDown(KeyCode.Space)) 
        {
            GameObject dirt = Instantiate(Dirt, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
            dirt.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
            GetComponent<AudioSource>().Play();
            for (int i=0; i<Data.Items.Length; i++)
            {
                if (Random.value <= Data.Probability[i])
                {
                    Interactable item = Instantiate(Data.Items[i], GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
                    item.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                }
            }
            nextTime = Time.time + cooldown;
            canDig = false;
        }
    }

    private bool isShovelSelected()
    {
        foreach (Slot slot in inventory.slots)
        {
            if (slot.isSelected && (slot.tag == "Stone Shovel" || slot.tag == "Steel Shovel" || slot.tag == "Blue Shovel" || slot.tag == "Rose Shovel")) return true;
        }
        return false;
    }

    public void SetDig(bool value) 
    {
        canDig = value;
    }
}
