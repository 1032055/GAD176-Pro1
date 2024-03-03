using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private GameObject deathPopUp;

    private Rigidbody2D rb;

    private Vector2 movementDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deathPopUp.SetActive(false);
    }


    private void Update()
    {
        GetInput();
        FaceMouse();
        if(playerHealth <= 0)
        {
            //for the user to implement their death screen or magic idk its up to them
            PlayerDied();
        }
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

    void FaceMouse()
    {
        //Used Unity Tutorial: Top down shooter movement (mouse and keyboard) by PitiIT on Youtube [0.13 - 2.33]

        //gets the position the mouse is at on screen and turns it into a vector 2
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //this moves the player from looking up to looking at where the mouse is relative to the object's current position
        transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision w player detyected");
        if(collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("Player hit enemy - ouchii");
            playerHealth--;
        }
    }

    void PlayerDied()
    {
        Time.timeScale = 0;
        deathPopUp.SetActive(true);
    }
}
