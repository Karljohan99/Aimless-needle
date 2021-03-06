﻿using System.Collections;
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

    public Interactable drop;

    public DropProbabilityData Data;
    public GameObject stone;

    public AudioClip DealDamage;

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
                if (drop != null)
                {

                    Interactable item1 = Instantiate(drop, transform.position, Quaternion.identity);
                    item1.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                }
                else
                {
                    int count = 0;
                    for (int i = 0; i < Data.Items.Length; i++)
                    {
                        if (Random.value <= Data.Probability[i] && count <= 2)
                        {
                            Interactable item1 = Instantiate(Data.Items[i], transform.position, Quaternion.identity);
                            item1.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                            count += 1;

                        }
                    }
                }
                Destroy(transform.parent.gameObject);
            }

            GameObject item = Instantiate(stone, transform.position, stone.transform.rotation);
            item.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
            Destroy(projectile);
        }
        if (collision.CompareTag("Player") && (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            Interactable weapon = getSelected();
            if (Time.time > nextHit && weapon != null)
            {
                GetComponent<AudioSource>().PlayOneShot(DealDamage);
                CurrentHealth -= weapon.damage;
                StartCoroutine(gotDamage());
                Healthbar.sizeDelta = new Vector2(CurrentHealth / MaxHealth * 100, Healthbar.sizeDelta.y);
                nextHit = Time.time + weapon.cooldown;
                if (CurrentHealth <= 0)
                {
                    if (drop != null)
                    {

                        Interactable item = Instantiate(drop, transform.position, Quaternion.identity);
                        item.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                    }
                    else
                    {
                        int count = 0;
                        for (int i = 0; i < Data.Items.Length; i++)
                        {
                            if (Random.value <= Data.Probability[i] && count<= 2)
                            {
                                Interactable item = Instantiate(Data.Items[i], transform.position, Quaternion.identity);
                                item.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
                                count += 1;
                            }
                        }
                    }
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

    

    IEnumerator gotDamage()
    {
        if (sprite.sprite == null)
        {
            sprite = gameObject.transform.parent.GetComponent<SpriteRenderer>();
        }


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
