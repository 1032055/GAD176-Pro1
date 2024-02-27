using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 movementDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }


    void GetInput()
    {
        // Handle player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movementDirection = new Vector2(horizontalInput, verticalInput);
    }

    void Move()
    {
        if(!rb)
        {
            return;
        }
        // Move the character
        rb.velocity = movementDirection * moveSpeed;
    }
}
