using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float Speed;
    private GameObject player;
    public int damage;
    private Vector3 target;
    private Vector3 difference;
    private Vector3 to;

    private EnemyHealth e;



    void Awake()
    {
        e = GameObject.FindGameObjectWithTag("Enemy")?.GetComponent<EnemyHealth>();
        player = GameObject.Find("Player");
        target = player.transform.position;
        difference = transform.position - target;

    }

    // Update is called once per frame
    void Update()
    {
        to = transform.position - difference;
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, to, step);
    }

    private void OnBecameInvisible()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            e.dam();
            Events.SetHealth(Events.RequestHealth() - damage);
            GameObject.Destroy(gameObject);
        }
    }
}
