using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    private GameObject playerObj;
    [SerializeField] int bulletSpeed, lifespan = 1;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        if (playerObj == null)
        {
            //Debug.Log("Please attach the player object"); dw, i got it >:)) - Need to note in user manual it's using the tag

            playerObj = GameObject.FindGameObjectWithTag("Player");
        }

        //same movement as the enemy objs but put in start because we dont want it changing direction
        bulletRb.velocity = (playerObj.transform.position - transform.position) * bulletSpeed * Time.deltaTime;
        StartCoroutine(BulletLifetime());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Bullket colliosion");
        // the ! wasnt working so this is how we live now. 
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("didnt die, hit " + collision.gameObject.tag);
            return;
        }
        else
        {
            //ded
            Destroy(this.gameObject);
        }   
    }

    IEnumerator BulletLifetime()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(this.gameObject);
    }
}
