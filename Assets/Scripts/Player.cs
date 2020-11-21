using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public GameObject winPanel;
    public GameObject losePanel;

    public RectTransform HealthBar;
    public TextMeshProUGUI HealthText;

    public AudioClip Footstep;

    private float health;
    private Inventory inventory;


    private void Awake()
    {            
        //DontDestroyOnLoad(transform.gameObject);
        Instance = this;
        inventory = gameObject.GetComponent<Inventory>();

        Events.OnWinLevel += WinLevel;
        Events.OnSetHealth += SetHealth;
        Events.OnRequestHealth += RequestHealth;
        Events.OnDie += Die;

        

    }

    private void OnDestroy()
    {
        Events.OnWinLevel -= WinLevel;
        Events.OnSetHealth -= SetHealth;
        Events.OnRequestHealth -= RequestHealth;
        Events.OnDie -= Die;
    }

    void Start()
    {
        Events.SetHealth(100);
    }

    void Update()
    {

    }

    public void SetHealth(float value)
    {
        health = Mathf.Max(value, 0);
        HealthText.text = health.ToString();
        HealthBar.sizeDelta = new Vector2(health*5, HealthBar.sizeDelta.y);
        if (health == 0) Die();
    }

    public float RequestHealth() => health;

    public void WinLevel()
    {
        winPanel.SetActive(true);
        gameObject.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Die()
    {
        for (int i=0; i<inventory.slots.Length; i++)
        {
            Slot slot = inventory.slots[i];
            for (int j=0; j<inventory.count[i]; j++)
            {
                slot.DropItem();
            }
        }
        losePanel.SetActive(true);
        gameObject.SetActive(false);
        //transform.position = new Vector3(-9, -27, 0);
        //Events.SetHealth(100);
    }

    public void PlayFootstep()
    {
        GetComponent<AudioSource>().PlayOneShot(Footstep);
    }
}
