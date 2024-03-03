using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] protected int enHealth, speed, attackDmg;
    [SerializeField] protected GameObject playerObj;
    [SerializeField] protected ParticleSystem explosion;
    
    protected Rigidbody2D enemyRb;

    protected virtual void Start()
    {
        // null reference check, it's well used cos instantiation did not like grabbing the right object
        if(playerObj == null)
        {
            //Debug.Log("Please attach the player object"); dw, i got it >:)) - Need to note in user manual it's using the tag

            playerObj = GameObject.FindGameObjectWithTag("Player");
        }

        // grab the rigid body
        enemyRb = GetComponent<Rigidbody2D>();

        if (enemyRb == null)
        {
            //this error works but if i ever see it, something's wrong with the prefab (i put the rb on the prefab)
            Debug.Log("Please attach a rigid body to the enemy");
        }
    }

    protected virtual void Update()
    {
        //check if its dead
        if(enHealth <= 0)
        {
            //if the enemy is dead, it will die
            EnemyDies(); 
        }
    }

    protected virtual void FixedUpdate()
    {
        EnemyMoveNdRotate();
    }

    protected virtual void EnemyMoveNdRotate()
    {
        /* pseudocode from Frank (i was struggling and he is awesome)

        get target position
        target position.x equals target position.x - transform position x
        target position.y equals target position.y - transform position y
        angle equals mathatan(targety, targetx) * mathrad2deg
        transform rotation equals = quaternion.euler(0,0,angle)
        */
        
        Vector3 playerPos = playerObj.transform.position;

        playerPos.x -= transform.position.x;
        playerPos.y -= transform.position.y;

        float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //now we gotta make em move
        // hopefully this will not take 6hrs
        //it did not lets goooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo

        enemyRb.velocity = (playerObj.transform.position - transform.position) * speed * Time.deltaTime; 
    }
    
    //checking the collision
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //matches it to the player object
        if(collision.gameObject == playerObj)
        {
            //Kills this enemy
            //Debug.Log("Enemy hits Player");
            
            enHealth = 0;
        }
    }

    protected virtual void EnemyDies()
    {
        // play an explode particle effect
        //not implemented yet
        Instantiate(explosion, this.transform.position, this.transform.rotation);

        //bye bye
        Destroy(this.gameObject);
    }
}