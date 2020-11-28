using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Start menu");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Player Scene");
        SceneManager.LoadScene("Grass Island", LoadSceneMode.Additive);
    }
    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
