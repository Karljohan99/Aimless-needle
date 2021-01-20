using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;

    private Inventory inventory;

    public RectTransform Healthbar;

    private float nextHit;

    private float CurrentHealth;

    public float EnemyDamage = 5;
    public float Cooldown = 3;

    private SpriteRenderer sprite;

    private float nextHit2;

    public GameObject drop;

    public DropProbabilityData Data;

    void Start()
    {
        CurrentHealth = MaxHealth;
        nextHit = Time.time;
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Inventory>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player Projectile"))
        {
            GameObject projectile = collision.gameObject;
            CurrentHealth -= 5;
            StartCoroutine(gotDamage());
            Healthbar.sizeDelta = new Vector2(CurrentHealth / MaxHealth * 100, Healthbar.sizeDelta.y);
            if (CurrentHealth <= 0)
            {

                Destroy(transform.parent.gameObject);
            }
            Destroy(projectile);
        }
        if (collision.CompareTag("Player") && (Input.GetKey(KeyCode.R) || Input.GetMouseButtonDown(0)))
        {
            Interactable weapon = getSelected();
            if (Time.time > nextHit && weapon != null)
            {
                CurrentHealth -= weapon.damage;
                StartCoroutine(gotDamage());
                Healthbar.sizeDelta = new Vector2(CurrentHealth / MaxHealth * 100, Healthbar.sizeDelta.y);
                nextHit = Time.time + weapon.cooldown;
                if (CurrentHealth <= 0)
                {

                    Destroy(transform.parent.gameObject);
                }
            }
        }
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && nextHit2 < Time.time)
        {
            Events.SetHealth(Events.RequestHealth() - EnemyDamage);
            player.GotDamage();
            nextHit2 = Time.time + Cooldown;
        }
    }

    private Interactable getSelected()
    {
        foreach (Slot slot in inventory.slots)
        {
            if (slot.isSelected)
            {
                return slot.transform.GetChild(1).GetComponent<InventoryButton>().dropItem;
            }
        }
        return null;
    }

    private void OnDestroy()
    {
        if(this.enabled){
            if (drop != null)
            {
                
                Instantiate(drop, transform.position, drop.transform.rotation);
                drop.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
            } else
            {
                for (int i = 0; i < Data.Items.Length; i++)
                {
                    if (Random.value <= Data.Probability[i])
                    {
                        Instantiate(Data.Items[i], transform.position, Quaternion.identity);
                        Data.Items[i].transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    }
                }
            }
        }   
    }

    IEnumerator gotDamage()
    {
        sprite.color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.07f);
        sprite.color = new Color(1, 1, 1, 1);

    }

    
}
