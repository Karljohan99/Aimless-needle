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

            else if (transform.name == "Door3")
            {
                SceneManager.UnloadSceneAsync(SceneName);
                SceneManager.LoadScene("Cave 2", LoadSceneMode.Additive);
                System.Threading.Thread.Sleep(500);
                GameObject.Find("Player").transform.position = new Vector3(2.9f, 11f, 0);
            }

            else if (transform.name == "Door4")
            {
                SceneManager.UnloadSceneAsync(SceneName);
                SceneManager.LoadScene("Small Island", LoadSceneMode.Additive);
                System.Threading.Thread.Sleep(500);
                GameObject.Find("Player").transform.position = new Vector3(-1f, 25f, 0);
            }

            else if (transform.name == "Door5")
            {
                SceneManager.UnloadSceneAsync(SceneName);
                SceneManager.LoadScene("Cave 3", LoadSceneMode.Additive);
                System.Threading.Thread.Sleep(500);
                GameObject.Find("Player").transform.position = new Vector3(12f, 11f, 0);
            }

            else if (transform.name == "Door6")
            {
                SceneManager.UnloadSceneAsync(SceneName);
                SceneManager.LoadScene("Waterfall Island", LoadSceneMode.Additive);
                System.Threading.Thread.Sleep(500);
                GameObject.Find("Player").transform.position = new Vector3(-12f, 21.1f, 0);
            }

            else if (SceneName == "Tutorial Island")
            {
                toGrassIsland();
            }
            else if (SceneName == "Grass Island")
            {
                pickRandom();
            }
            else if (SceneName == "Mountain Island")
            {
                pickRandom();
            }
            else if (SceneName == "Small Island")
            {
                pickRandom();
            }
            else if (SceneName == "Waterfall Island")
            {
                pickRandom();
            }
        }
    }

    public void pickRandom()
    {
        var islands = new List<string>{ "Grass Island","Mountain Island","Small Island","Waterfall Island"};
        islands.Remove(SceneName);
        string island = islands[Random.Range(0, 3)];
        switch(island)
        {
            case "Grass Island":
                toGrassIsland();
                break;
            case "Mountain Island":
                toMountainIsland();
                break;
            case "Small Island":
                toSmallIsland();
                break;
            case "Waterfall Island":
                toWaterfallIsland();
                break;
        }
    }

    public void toGrassIsland()
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Grass Island", LoadSceneMode.Additive);
        System.Threading.Thread.Sleep(500);
        GameObject.Find("Player").transform.position = new Vector3(-9, -27, 0);
    }
    public void toMountainIsland()
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Mountain Island", LoadSceneMode.Additive);
        System.Threading.Thread.Sleep(500);
        GameObject.Find("Player").transform.position = new Vector3(0, -12, 0);
    }

    public void toSmallIsland()
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Small Island", LoadSceneMode.Additive);
        System.Threading.Thread.Sleep(500);
        GameObject.Find("Player").transform.position = new Vector3(-21, 0, 0);
    }

    public void toWaterfallIsland()
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Waterfall Island", LoadSceneMode.Additive);
        System.Threading.Thread.Sleep(500);
        GameObject.Find("Player").transform.position = new Vector3(-18, 10, 0);
    }
}
