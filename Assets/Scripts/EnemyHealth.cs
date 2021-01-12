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

    private float nextHit2;

    void Start()
    {
        CurrentHealth = MaxHealth;
        nextHit = Time.time;
    }

    
    void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Inventory>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.R))
        {
            Interactable weapon = getSelected();
            if (Time.time > nextHit && weapon != null)
            {
                CurrentHealth -= weapon.damage;
                Healthbar.sizeDelta = new Vector2(CurrentHealth/MaxHealth*100, Healthbar.sizeDelta.y);
                nextHit = Time.time + weapon.cooldown;
                if (CurrentHealth <= 0) Destroy(transform.parent.gameObject);
            }
        }
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && nextHit2 < Time.time)
        {
            Events.SetHealth(Events.RequestHealth() - EnemyDamage);
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
}
