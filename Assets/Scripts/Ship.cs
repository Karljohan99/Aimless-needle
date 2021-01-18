using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public Canvas ShipCanvas;
    public CraftingTable CraftingTable;
    public Button CraftingTableButton;
    public Button LeaveButton;
    public string SceneName;
    public float ShipDelay = 60;

    private float nextLeaveTime;
    private Inventory inventory;

    void Start()
    {
        ShipCanvas.enabled = false;
        CraftingTableButton.onClick.AddListener(EnableCraftingTable);
        LeaveButton.onClick.AddListener(LeaveIsland);
        if (Events.RequestSceneName() != "Tutorial Island" && checkPlayer())
        {
            LeaveButton.interactable = false;
            nextLeaveTime = Time.time + ShipDelay;
        }
    }

    void Update()
    {
        if (Time.time > nextLeaveTime) LeaveButton.interactable = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShipCanvas.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ShipCanvas.enabled = false;
            CraftingTable.Canvas.enabled = false;
        }
    }

    private void EnableCraftingTable()
    {
        ShipCanvas.enabled = false;
        CraftingTable.Canvas.enabled = true;
    }

    public void LeaveIsland()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        foreach (Slot slot in inventory.slots) 
        {
            if (slot.tag == "Compass") Events.WinLevel();
        }
        
        if (SceneName == "Tutorial Island")
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
        else if (SceneName == "Palm Island") 
        {
            pickRandom();
        }
    }
    

    public void pickRandom()
    {
        var islands = new List<string>{ "Grass Island","Mountain Island","Small Island","Waterfall Island", "Palm Island"};
        islands.Remove(SceneName);
        string island = islands[Random.Range(0, 4)];
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
            case "Palm Island":
                toPalmIsland();
                break;
        }
    }

    public void toGrassIsland()
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Grass Island", LoadSceneMode.Additive);
        Events.ChangeScene("Grass Island");
        GameObject.Find("Player").transform.position = new Vector3(-9, -27, 0);
    }
    public void toMountainIsland()
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Mountain Island", LoadSceneMode.Additive);
        Events.ChangeScene("Mountain Island");
        GameObject.Find("Player").transform.position = new Vector3(0, -12, 0);
    }

    public void toSmallIsland()
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Small Island", LoadSceneMode.Additive);
        Events.ChangeScene("Small Island");
        GameObject.Find("Player").transform.position = new Vector3(-21, 0, 0);
    }

    public void toWaterfallIsland()
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Waterfall Island", LoadSceneMode.Additive);
        Events.ChangeScene("Waterfall Island");
        GameObject.Find("Player").transform.position = new Vector3(-18, 10, 0);
    }

    public void toPalmIsland()
    {
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.LoadScene("Palm Island", LoadSceneMode.Additive);
        Events.ChangeScene("Palm Island");
        GameObject.Find("Player").transform.position = new Vector3(-20, 6, 0);
    }

    private bool checkPlayer() 
    {
        bool b = false;
        switch(Events.RequestSceneName())
        {
        case "Grass Island":
            if (GameObject.Find("Player").transform.position == new Vector3(-9, -27, 0))   b = true;
            break;
        case "Mountain Island":
            if (GameObject.Find("Player").transform.position == new Vector3(0, -12, 0)) b =  true;;
            break;
        case "Small Island":
            if (GameObject.Find("Player").transform.position == new Vector3(-21, 0, 0)) b =  true;
            break;
        case "Waterfall Island":
            if (GameObject.Find("Player").transform.position == new Vector3(-18, 10, 0)) b =  true;
            break;
        case "Palm Island":
            if (GameObject.Find("Player").transform.position == new Vector3(-20, 6, 0)) b =  true;
            break;
        }
        return b;
    }
}
