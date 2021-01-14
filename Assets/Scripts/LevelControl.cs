using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    private float DelayTime;
    
    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (transform.name == "Door")
            {
                SceneManager.UnloadSceneAsync("Mountain Island");
                SceneManager.LoadScene("Cave 1", LoadSceneMode.Additive);
                GameObject.Find("Player").transform.position = new Vector3(-2.2f, -13f, 0);
            }
          
            else if (transform.name == "Door2")
            {
                SceneManager.UnloadSceneAsync("Cave 1");
                SceneManager.LoadScene("Mountain Island", LoadSceneMode.Additive);
                GameObject.Find("Player").transform.position = new Vector3(-16.6f, 40.5f, 0);
            }

            else if (transform.name == "Door3")
            {
                SceneManager.UnloadSceneAsync("Small Island");
                SceneManager.LoadScene("Cave 2", LoadSceneMode.Additive);
                GameObject.Find("Player").transform.position = new Vector3(2.9f, 10f, 0);
            }

            else if (transform.name == "Door4")
            {
                SceneManager.UnloadSceneAsync("Cave 2");
                SceneManager.LoadScene("Small Island", LoadSceneMode.Additive);
                GameObject.Find("Player").transform.position = new Vector3(-1f, 23.5f, 0);
            }

            else if (transform.name == "Door5")
            {
                SceneManager.UnloadSceneAsync("Waterfall Island");
                SceneManager.LoadScene("Cave 3", LoadSceneMode.Additive);
                GameObject.Find("Player").transform.position = new Vector3(12f, 10f, 0);
            }

            else if (transform.name == "Door6")
            {
                SceneManager.UnloadSceneAsync("Cave 3");
                SceneManager.LoadScene("Waterfall Island", LoadSceneMode.Additive);
                GameObject.Find("Player").transform.position = new Vector3(-12f, 20f, 0);
            }
        }
    }
}
