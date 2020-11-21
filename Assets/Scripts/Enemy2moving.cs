﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2moving : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;
    public float min = 2f;
    public float max = 4f;
    private Vector3 previousPos;
    public EnemyProjectile stone;
    public float StoneDelay;
    private float NextSpawnTime;
    public string moving;

    private float RotateSpeed = 2.6f;
    private float Radius = 1.2f;

    private Vector2 _centre;
    private float _angle;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        min = transform.position.x;
        max = transform.position.x + 3;
        NextSpawnTime = Time.time;

        _centre = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        previousPos = transform.position;

        
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSite)
        {
            
            if (Time.time >= NextSpawnTime && stone != null)
            {
                EnemyProjectile enemyprojectile = GameObject.Instantiate<EnemyProjectile>(stone, transform.position, Quaternion.identity, null);
                NextSpawnTime += StoneDelay;
            }
            else if (Time.time >= NextSpawnTime)
            {
                NextSpawnTime += StoneDelay;
            }

        } else { NextSpawnTime = Time.time; }

        if (moving == "circle")
        {
            _angle += RotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _centre + offset;


        } else if (moving == "line")
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

        }

        if (previousPos.x - transform.position.x >= 0.01f)
        {
            transform.localScale = new Vector3(-System.Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (previousPos.x - transform.position.x <= -0.01f)
        {
            transform.localScale = new Vector3(System.Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
