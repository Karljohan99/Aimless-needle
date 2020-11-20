using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/DiggingProbabilityData")]
public class DiggingProbabilityData : ScriptableObject
{
    public Interactable[] Items;
    public float[] Probability;
}
