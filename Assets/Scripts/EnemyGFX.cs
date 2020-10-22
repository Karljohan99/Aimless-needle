﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    public float EnemyDamage = 5;
    public float Cooldown = 3;
    
    private float nextHit;
 
    void Start()
    {
        nextHit = Time.time;
    }

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && nextHit < Time.time)
        {
            Events.SetHealth(Events.RequestHealth() - EnemyDamage);
            nextHit = Time.time + Cooldown;
        }
    }
}
