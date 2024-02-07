using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float speed = 100f;
    public Rigidbody2D rb;
    private Vector2 movementDirection;
    public float x, y;
    public Animator animator;
    private bool isWalking;


    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        // Running 
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            speed = 5f;
        else
            speed = 2f;


        movementDirection = new Vector2(x, y).normalized;

       
    }

    private void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * speed * Time.deltaTime;

        // Running
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            speed = 180f;
        else
        {
            speed = 100f;
        }

    }
}