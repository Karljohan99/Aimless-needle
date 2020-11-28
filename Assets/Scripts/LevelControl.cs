using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public string SceneName;

    private float DelayTime;
    
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
            print(DelayTime);

            if (transform.name == "Door")
            {
                SceneManager.UnloadSceneAsync(SceneName);
                SceneManager.LoadScene("Cave 1", LoadSceneMode.Additive);
                System.Threading.Thread.Sleep(500);
                GameObject.Find("Player").transform.position = new Vector3(-2.2f, -14.8f, 0);
            }
            else if (transform.name == "Door2")
            {
                SceneManager.UnloadSceneAsync(SceneName);
                SceneManager.LoadScene("Mountain Island", LoadSceneMode.Additive);
                System.Threading.Thread.Sleep(500);
                GameObject.Find("Player").transform.position = new Vector3(-16.6f, 41.8f, 0);
            }
            else if (SceneName == "Grass Island")
            {
                SceneManager.UnloadSceneAsync(SceneName);
                SceneManager.LoadScene("Mountain Island", LoadSceneMode.Additive);
                System.Threading.Thread.Sleep(500);
                GameObject.Find("Player").transform.position = new Vector3(1, -12, 0);
                
            }
            else if (SceneName == "Mountain Island")
            {
                SceneManager.UnloadSceneAsync(SceneName);
                SceneManager.LoadScene("Grass Island", LoadSceneMode.Additive);
                System.Threading.Thread.Sleep(500);
                GameObject.Find("Player").transform.position = new Vector3(-9, -27, 0);
            } 
            
        }
    }
}
