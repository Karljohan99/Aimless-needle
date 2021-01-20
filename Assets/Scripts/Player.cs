using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public GameObject winPanel;
    public GameObject losePanel;


    public RectTransform HealthBar;
    public TextMeshProUGUI HealthText;

    public AudioClip Footstep;
    public AudioClip TakeDamage;

    private float health;
    private Inventory inventory;

    private SpriteRenderer sprite;


    private void Awake()
    {            
        //DontDestroyOnLoad(transform.gameObject);
        Instance = this;
        inventory = gameObject.GetComponent<Inventory>();

        Events.OnWinLevel += WinLevel;
        Events.OnSetHealth += SetHealth;
        Events.OnRequestHealth += RequestHealth;
        Events.OnDie += Die;
        sprite = GetComponent<SpriteRenderer>();

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
        if (value < health) 
        {
            GetComponent<AudioSource>().PlayOneShot(TakeDamage); 
        }
        health = Mathf.Max(value, 0);
        health = Mathf.Clamp(health, 0, 100);
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
                var match = Regex.Match(slot.tag, @"^Compass\d?$");
                if (match.Success)
                {
                    slot.DropItem();
                }
                else 
                {
                    slot.RemoveItem(i);
                }
            }
        }
        losePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PlayFootstep()
    {
        GetComponent<AudioSource>().PlayOneShot(Footstep);
    }

    IEnumerator Blinking()
    {
        sprite.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 1);
    }

    public void GotDamage()
    {
        StartCoroutine(Blinking());
    }
}
