using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetKey(KeyCode.N))
        {
            int scene = SceneManager.GetActiveScene().buildIndex;

            if (transform.name == "Door")
            {
                //GameObject.Find("Player").transform.position = new Vector3(-2.2f, -14.8f, 0);
                SceneManager.LoadScene(3);
            }
            else if (transform.name == "Door2")
            {
                //GameObject.Find("Player").transform.position = new Vector3(-16.6f, 41.8f, 0);
                SceneManager.LoadScene(2);
            }
            else if (scene == 1)
            {
                SceneManager.LoadScene(2);
            }
            else if (scene == 2)
            {
                SceneManager.LoadScene(1);
            } 
            
        }
    }
}
