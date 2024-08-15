using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool Alive = true;

    public float PlayerRange;

    public Rigidbody2D rb;

    public float moveSpeed;

    void Start()
    {
        
    }

    void Update()
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
        Destroy(gameObject);
    }
}
