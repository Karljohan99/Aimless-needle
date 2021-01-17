using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    public GameObject PauseMenu;
    public GameObject player;
    public GameObject controlsMenu;
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                PauseMenu.SetActive(true);
                player.SetActive(false);
                
            }
            else
            {
                PauseMenu.SetActive(false);
                player.SetActive(true);
                
            }
        }
    }
    public void Resume()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(false);
        player.SetActive(true);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start menu");
    }

    public void OpenControls()
    {
        PauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void returnMenu()
    {
        controlsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }
}
