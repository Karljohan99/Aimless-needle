using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCardPresenter : MonoBehaviour
{
    public ItemData ItemData;
    public int Amount;
    public TextMeshProUGUI AmountText;

    void Awake()
    {
        gameObject.GetComponent<Image>().sprite = ItemData.Sprite;
        AmountText.text = Amount.ToString();
    }
}
