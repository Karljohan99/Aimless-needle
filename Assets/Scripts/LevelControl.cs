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
            if (scene == 1)
            {
                SceneManager.LoadScene(2);
            } else if (scene == 2)
            {
                SceneManager.LoadScene(1);
            }
            
        }
    }
}
