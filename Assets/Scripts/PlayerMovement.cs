using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal;
    float vertical;

    float speedLimit = 0.5f;

    public float runSpeed = 10.0f;

    void Start()
    {
        // We take our player body.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        // -1 is left ; 1 is right
        horizontal = Input.GetAxisRaw("Horizontal");
        // Gives a value between -1 and 1
        // -1 is down; 1 is up
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    void FixedUpdate()
    {
        // Check for diagonal movement. On diagonal movement the speed should be decreased to 70%.
        if (horizontal != 0 && vertical != 0) 
        {
            horizontal *= speedLimit;
            vertical *= speedLimit;
        }
        // Update the actual speed
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
