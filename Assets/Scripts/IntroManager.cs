using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public GameObject player;
    public GameObject introPanel;
    public GameObject controlsPanel;
    public GameObject all;

    // Start is called before the first frame update
    


    // Update is called once per frame
    void Update()
    {
        player.SetActive(false);
    }

    public void Continue()
    {
        all.SetActive(false);
        player.SetActive(true);
    }

    public void Next()
    {
        controlsPanel.SetActive(true);
        introPanel.SetActive(false);
        
        
    }
}
