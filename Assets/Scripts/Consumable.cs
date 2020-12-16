using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Consumable : MonoBehaviour, IPointerClickHandler {

    List<string> tags;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        tags = new List<string>();
        foreach (Slot slot in inventory.slots)
        {
            tags.Add(slot.tag);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            int i = tags.IndexOf(gameObject.tag);
            float restore = gameObject.GetComponent<InventoryButton>().dropItem.restoreHP;
            Events.SetHealth(Events.RequestHealth() + restore);
            Events.RemoveItem(i);
        }
    }
}
