using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/ItemData")]

public class ItemData : ScriptableObject
{
    public GameObject ItemButton;
    public int MaxStack;
    public float Damage = 0;
    public float Cooldown = 1;
    public string Tag;
    public Sprite Sprite;
}
