using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;

    private Inventory inventory;

    public RectTransform Healthbar;

    public EnemyGFX enemy;

    private float nextHit; 

    private float CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    
    void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        if(enemy.aiPath.desiredVelocity.x >= 0.01f)
        {
            Healthbar.transform.localScale = new Vector3(1f, 1f, 1f);
            Healthbar.anchorMin = new Vector2(0, 0.5f);
            Healthbar.anchorMax = new Vector2(0, 0.5f);
        } else if (enemy.aiPath.desiredVelocity.x <= -0.01f)
        {
            Healthbar.transform.localScale = new Vector3(-1f, 1f, 1f);
            Healthbar.anchorMin = new Vector2(1, 0.5f);
            Healthbar.anchorMax = new Vector2(1, 0.5f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.R))
        {
            Interactable weapon = getSelected();
            if (Time.time > nextHit)
            {
                CurrentHealth -= weapon.damage;
                Healthbar.sizeDelta = new Vector2(CurrentHealth/MaxHealth*100, Healthbar.sizeDelta.y);
                nextHit = Time.time + weapon.cooldown;
                if (CurrentHealth <= 0) Destroy(gameObject);
            }
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
