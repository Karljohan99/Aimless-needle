using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public CraftingTableData Data;
    public Canvas Canvas;
    public CraftingCardPresenter CraftingCard;

    private int cardIndex = 0;

    void Awake()
    {
        Canvas.enabled = false;
        Events.OnNextCraftingCard += NextCraftingCard;
        Events.OnPreviousCraftingCard += PreviousCraftingCard;
    }

    private void OnDestroy()
    {
        Events.OnNextCraftingCard -= NextCraftingCard;
        Events.OnPreviousCraftingCard -= PreviousCraftingCard;
    }

    void Start()
    {
        SetCraftingPanel();
    }


    void Update()
    {

    }

    public void SetCraftingPanel()
    {
         foreach (Transform child in Canvas.transform)
         {
             Destroy(child.gameObject);
         }
        CraftingCard.Data = Data;
        CraftingCard.index = cardIndex;
        CraftingCardPresenter craftingCard = Instantiate(CraftingCard);
        craftingCard.transform.SetParent(Canvas.transform);
        craftingCard.transform.localScale = new Vector3(1,1,1);
        craftingCard.transform.localPosition = new Vector3(0,0,0);
    }

    private void NextCraftingCard()
    {
        if (cardIndex + 1 > Data.Panels.Length - 1)
        {
            cardIndex = 0;
        }
        else 
        {
            cardIndex += 1;
        }
        SetCraftingPanel();
    }

    private void PreviousCraftingCard()
    {
        if (cardIndex - 1 < 0)
        {
            cardIndex = Data.Panels.Length - 1;
        }
        else 
        {
            cardIndex -= 1;
        }
        SetCraftingPanel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Canvas.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Canvas.enabled = false;
        }
    }
}
