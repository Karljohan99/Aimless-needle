using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    private string sceneName;

    void Awake()
    {
        Events.OnChangeScene += Change;
        Events.OnRequestSceneName += RequestSceneName;
        foreach (Transform child in transform)
        {
            if (child.name == "Tutorial Island") child.gameObject.SetActive(true);
            else child.gameObject.SetActive(false);
        }
        sceneName = "Tutorial Island";
    }

    void Update()
    {
        
    }

    void OnDestroy()
    {
        Events.OnChangeScene -= Change;
        Events.OnRequestSceneName -= RequestSceneName;
    }

    public string RequestSceneName() => sceneName;

    public void Change(string SceneName)
    {
        foreach (Transform child in transform)
        {
            if (child.name == SceneName)
            {
                child.gameObject.SetActive(true);
                sceneName = SceneName;
            }
            else 
            {
                child.gameObject.SetActive(false);
            }
        }
        
    }
}
