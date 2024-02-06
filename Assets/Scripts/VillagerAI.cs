using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class VillagerAI : MonoBehaviour
{
    public Vector2[] points; //list of destinations
    public float moveSpeed = 1;
    public float turnSpeed = 100;
    public float waitTime = 1;
    public float visionAngle = 30;
    public float visionRange = 5;
    public GameObject anchor; //rotate this when the angle of the NPC changes (can be left null)
    public GameObject playerGameObject; //use this to find player (needed to run script)
    public Action onTrigger = () => { }; // run this when player is found

    private Rigidbody2D rb;
    private Rigidbody2D playerRb;
    private float angle = 0;
    private int currentDestination = 0;
    private Vector2 baseVector = Vector2.up;
    private float speed;
    private Action mode;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRb = playerGameObject.GetComponent<Rigidbody2D>();
        speed = moveSpeed;
        mode = Move;
        angle = Vector2.Angle(rb.position, points[currentDestination]);
    }


    private void FixedUpdate()
    {
        mode.Invoke();
        FindPlayer();
        MoveAnchor();
    }


    //turn NPC towards the new destination
    private void Turn()
    {
        float target = Vector2.SignedAngle(baseVector, rb.position - points[currentDestination]);
        //Debug.Log("angle: " + angle + " target: " + target + " position: " + rb.position + " target: " + points[current]);

        if (angle == target)
        {
            mode = Move;
        }
        else
        {
            angle = Mathf.MoveTowardsAngle(angle, target, turnSpeed * Time.fixedDeltaTime);
        }
    }

    //move NPC towards next destination, when arrived wait and then turn
    private void Move()
    {
        Vector2 position = rb.position;
        if (math.abs(position.x - points[currentDestination].x) == 0 &&
            math.abs(position.y - points[currentDestination].y) == 0)
        {
            currentDestination = (currentDestination + 1) % (points.Length);
            StartCoroutine(Wait(waitTime));
            mode = Turn;
            return;
        }
        Vector2 newPosition = Vector2.MoveTowards(position, points[currentDestination], speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }

    private void MoveAnchor() 
    {
        if (anchor != null)
        {
            anchor.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    
    //check if player is inside vision. if true then invoke onTrigger
    //onTrigger gets invoked on every FixedUpdate!
    private void FindPlayer() 
    {
        float angleToPlayer = Vector2.SignedAngle(baseVector, rb.position - playerRb.position);
        float angleDifference = (angle - angleToPlayer) % 180;
        //Debug.Log("diff: " + angleDifference);

        if ((math.abs(angleDifference) < visionAngle) && (Physics2D.Raycast(rb.position, (playerRb.position - rb.position), visionRange).rigidbody == playerRb)) 
        {
            onTrigger.Invoke();
            Debug.Log("player found!");
        }
    }

    IEnumerator Wait(float time)
    {
        speed = 0;
        yield return new WaitForSeconds(time);
        speed = moveSpeed;
    }
}
