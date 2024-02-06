

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody2D rb;
    private Vector3 movementDirection;
    public float x, y;
    public Animator animator;
    private bool isWalking;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
 
        if(x != 0 || y != 0)
        {
            animator.SetFloat("Horizontal", x);
            animator.SetFloat("Vertical", y);

            if (!isWalking)
            {
                isWalking = true;
                animator.SetBool("isMoving", isWalking);
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                animator.SetBool("isMoving", isWalking);
                StopMoving();
            }
        }

        movementDirection = new Vector3(x, y).normalized;

       
    }

    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
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