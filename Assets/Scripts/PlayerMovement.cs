using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public Animator animator;

    private Vector3 movement;

    public Rigidbody2D rigidBody;
    public bool knockback;
    public float thrust;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (knockback)
        {
            knockback = !knockback;
            rigidBody.AddForce(transform.right * -thrust);
            rigidBody.AddForce(transform.up * thrust);
        } else
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }      

    }

    void FixedUpdate()
    {
        this.transform.position += movement*Time.deltaTime*movementSpeed;
    }
}
