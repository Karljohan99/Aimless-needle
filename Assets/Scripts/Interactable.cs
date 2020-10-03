using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Interactable : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            GameObject.Destroy(gameObject);

            //TODO: kustutamise asemel pane gameobject invetori

        }
    }
}
