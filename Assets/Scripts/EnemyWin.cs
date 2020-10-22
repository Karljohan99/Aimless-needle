using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWin : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.childCount == 0) Events.WinLevel();
    }
}
