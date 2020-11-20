using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showel : MonoBehaviour
{
    public GameObject Dirt;

    public DiggingProbabilityData Data;

    private Inventory inventory;

    private bool canDig = true;

    private void Awake()
    {            
        Events.OnSetDig += SetDig;
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
        if (canDig && isShovelSelected() && Input.GetKey(KeyCode.R)) 
        {
            Instantiate(Dirt, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            for (int i=0; i<Data.Items.Length; i++)
            {
                if (Random.value <= Data.Probability[i])
                {
                    Instantiate(Data.Items[i], GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
                }
            }
            canDig = false;
        }
    }

    private bool isShovelSelected()
    {
        foreach (Slot slot in inventory.slots)
        {
            if (slot.isSelected && slot.tag == "Stone Shovel") return true;
        }
        return false;
    }

    public void SetDig(bool value) 
    {
        canDig = value;
    }
}
