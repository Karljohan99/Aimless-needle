using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/DropProbabilityData")]
public class DropProbabilityData : ScriptableObject
{
    public Interactable[] Items;
    public float[] Probability;
}