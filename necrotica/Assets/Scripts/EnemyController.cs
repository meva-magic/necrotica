using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health = 3;

    public float PlayerRange;

    public Rigidbody2D rb;

    private float moveSpeed = 3;
    
    
    private void Update()
    {
        if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) < PlayerRange)
        {
            Vector3 playerDirection = PlayerMovement.instance.transform.position - transform.position;

            rb.velocity = playerDirection.normalized * moveSpeed;
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

