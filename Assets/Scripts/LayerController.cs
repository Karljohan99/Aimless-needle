using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    void Start()
    {
        checkLayer();
    }

    void Update()
    {
        checkLayer();
    }

    private void checkLayer()
    {
        if (gameObject.transform.position.y < Player.Instance.transform.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Infront of player";
        }
        else 
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Behind player";
        }
    }
}
