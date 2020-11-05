using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/CraftingTableData")]

public class CraftingTableData : ScriptableObject
{
    public CraftingTablePanelData[] Panels;
}
