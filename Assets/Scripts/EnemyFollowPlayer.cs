using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;
    private AIDestinationSetter tr;
    public float min = 2f;
    public float max = 3f;


    // Start is called before the first frame update
    void Start()
    {
        tr = transform.parent.GetComponent<AIDestinationSetter>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        min = transform.position.x;
        max = transform.position.x + 3;
    }

    // Update is called once per frame
    void Update()
    {

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if(distanceFromPlayer<lineOfSite && distanceFromPlayer > 1.5)
        {
            tr.enabled = true;
        } else if (distanceFromPlayer <= 1.5)
        {
            tr.enabled = false;
        } else 
        {
            tr.enabled = false;
            //transform.parent.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
            //transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
        }



        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
