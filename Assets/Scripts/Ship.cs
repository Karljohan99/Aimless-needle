using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public Canvas ShipCanvas;
    public CraftingTable CraftingTable;
    public Button CraftingTableButton;
    public Button LeaveButton;

    void Start()
    {
        ShipCanvas.enabled = false;
        CraftingTableButton.onClick.AddListener(enableCraftingTable);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShipCanvas.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShipCanvas.enabled = false;
            CraftingTable.Canvas.enabled = false;
        }
    }

    private void enableCraftingTable()
    {
        ShipCanvas.enabled = false;
        CraftingTable.Canvas.enabled = true;
    }
}
