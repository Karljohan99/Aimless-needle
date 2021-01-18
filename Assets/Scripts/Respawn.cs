using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{ 
    public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RespawnPlayer() 
    {
        gameObject.SetActive(false);
        player.SetActive(true);
        Events.SetHealth(100);
        switch(Events.RequestSceneName())
        {
            case "Tutorial Island":
                player.transform.position = new Vector3(-22, 12, 0);
                break;
            case "Grass Island":
                player.transform.position = new Vector3(-9, -27, 0);
                break;
            case "Mountain Island":
                player.transform.position = new Vector3(0, -12, 0);
                break;
            case "Small Island":
                player.transform.position = new Vector3(-21, 0, 0);
                break;
            case "Waterfall Island":
                player.transform.position = new Vector3(-18, 10, 0);
                break;
            case "Palm Island":
                player.transform.position = new Vector3(-20, 6, 0);
                break;
        }
    }
}
