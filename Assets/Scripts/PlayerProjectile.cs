using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float Speed;
    private Vector3 target;
    private Vector3 difference;
    private Vector3 to;

    public GameObject drop;

    private bool dropped = false;



    private void Awake()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        difference = transform.position - target;
    }

    // Start is called before the first frame update
    void Start()
    {
        to = transform.position - difference;
    }

    // Update is called once per frame
    void Update()
    {
        
        float step = Speed * Time.deltaTime;
        
        if (Vector3.Distance(transform.position, to) < 0.5f && !dropped)
        {
            GameObject item = Instantiate(drop, transform.position, drop.transform.rotation);
            item.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
            dropped = true;
            Destroy(this.gameObject);
        }


        transform.position = Vector3.MoveTowards(transform.position, to, step);

    }

   
}
