using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public TextMeshProUGUI countText;
    

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
     
    }

    void Update()
    {
       if (transform.childCount <=1)
        {
            inventory.isFull[i] = false;
            inventory.slots[i].tag = "Untagged";
        }
        countText.text = inventory.count[i].ToString();
       
    }

    //public void dropitem()
    //{
    //    foreach (transform child in transform)
    //    {
    //        gameobject.destroy(child.gameobject);
    //    }
    //    inventory.count[i] -= 1;
    //}

    public void ItemSelected()
    {

    }

    public void SetCount(int count)
    {
        countText.text = count.ToString();
    }

}
