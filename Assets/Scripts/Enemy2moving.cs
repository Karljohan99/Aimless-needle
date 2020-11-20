using System.Collections;
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


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        min = transform.position.x;
        max = transform.position.x + 3;
        NextSpawnTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        previousPos = transform.position;

        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

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

        }
        if (previousPos.x -transform.position.x >= 0.01f)
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
