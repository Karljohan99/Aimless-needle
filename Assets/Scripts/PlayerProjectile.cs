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



    private void Awake()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(target);
        difference = transform.position - target;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        to = transform.position - difference;
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, to, step);

    }

    private void OnDestroy()
    {
       
        Instantiate(drop, transform.position, drop.transform.rotation);
        drop.transform.SetParent(GameObject.FindGameObjectWithTag(Events.RequestSceneName()).transform);
    }
}
