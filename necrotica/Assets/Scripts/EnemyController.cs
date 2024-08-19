using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health = 3;

    public float PlayerRange;

    public Rigidbody2D rb;

    public float moveSpeed;


    public bool shootingType;

    public float fireRate;

    private float shotCounter;

    public GameObject bullet;

    public Transform firePoint;

    
    private void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < PlayerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            rb.velocity = playerDirection.normalized * moveSpeed;

            if(shootingType)
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage()
    {
        AudioManager.instance.Play("EnemyHit");
        health -= 1;

        if(health <= 0)
        {Destroy(gameObject);}
    }
}

