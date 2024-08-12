using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float PlayerRange = 6f;

    public Rigidbody2D rb;

    public float moveSpeed;

    public bool Alive = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < PlayerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            rb.velocity = playerDirection.normalized * moveSpeed;
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
