using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexEnemy : BasicEnemy
{
    [SerializeField] GameObject bulletPrefab;
    //[SerializeField] int ammo;
    private float shootTime = 0f, shootRate = 0.5f;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void EnemyMoveNdRotate()
    {
        //we want most of the same functionality, not all though
        Vector3 playerPos = playerObj.transform.position;

        playerPos.x -= transform.position.x;
        playerPos.y -= transform.position.y;

        float angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //want it to stop a bit before the player
        if (Vector2.Distance(playerObj.transform.position, transform.position) > 2)
        {
            //move if out of range
            //Debug.Log(Vector2.Distance(playerObj.transform.position, transform.position));
            enemyRb.velocity = (playerObj.transform.position - transform.position) * speed * Time.deltaTime;
        }
        else
        {
            //stop moving
            enemyRb.velocity = Vector2.zero;
            EnemyShoot();
        }

    }

    void EnemyShoot()
    {
        if (Time.time > shootTime)
        {
            Debug.Log("pew");
            shootTime = Time.time + shootRate;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}
