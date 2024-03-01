using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMovement : MonoBehaviour
{
    public float leftBound = -1f; // Define the left bound for the stone movement
    public float rightBound = 1f; // Define the right bound for the stone movement

    private Vector3 initialPosition; // Store the initial position of the stone

    private void Start()
    {
        initialPosition = transform.position; // Store the initial position
    }

    private void Update()
    {
        // Calculate the position where the stone can be moved to
        float targetX = Mathf.Clamp(transform.position.x, initialPosition.x + leftBound, initialPosition.x + rightBound);

        // Update the position of the stone
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
