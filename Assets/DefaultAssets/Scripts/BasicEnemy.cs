using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private int enHealth, speed, attackDmg;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private float testZ, testY, testX;
    
    private Rigidbody2D enemyRb;

    private Vector2 targetPos = Vector2.zero;
        

    void Start()
    {
        if(playerObj == null)
        {
            //Debug.Log("Please attach the player object"); dw, i got it >:))

            playerObj = GameObject.FindGameObjectWithTag("Player");
        }

        enemyRb = GetComponent<Rigidbody2D>();

        if (enemyRb == null)
        {
            Debug.Log("Please attach a rigid body to the enemy");
        }
    }

    void Update()
    {
        //check if its dead
        if(enHealth <= 0)
        {
            //EnemyDies(); 
        }

        //Use Math A-Tan and Angle Axis
        //
        //Vector2 relative = transform.InverseTransformPoint(targetPos);
        //float angle = Mathf.Atan2(relative.y, relative.x);
        //transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);

        //transform.LookAt(targetPos);

        Vector3 relativePos = playerObj.transform.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        transform.rotation = rotation;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == playerObj)
        {
            Debug.Log("Enemy hits Player");
            
            enHealth = 0;
        }
    }

    protected virtual void EnemyDies()
    {
        // play an explode particle effect
        //not implemented yet

        //bye bye
        Destroy(this.gameObject);
    }
    /* 
    
    if (playerObj != null)
        {
            // Get the direction from this object to the target object
            Vector3 direction = playerObj.transform.position - transform.position;

            // Calculate the angle from the current direction to the target direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply the rotation to make this object look at the target
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


    //Get the player's position
    Vector3 playerPos = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, playerObj.transform.position.z);
    //testY = playerObj.transform.position.y;

    //Vector3 vectorTest = new Vector3(0, 0, testZ);
    //vectorTest.x = transform.position.x;
    //vectorTest.y = transform.position.y;
    //vectorTest.y = transform.position.y;

    transform.LookAt(playerPos);
    Vector3 newEnemyRot = new Vector3(enemyRotXY.x, enemyRotXY.y, transform.rotation.z);
    transform.rotation = Quaternion.Euler(newEnemyRot);
    //Debug.Log("Go to " + targetPos); // This worked :))

    //enemyRb.velocity = targetPos * speed * Time.deltaTime;
    */
}

