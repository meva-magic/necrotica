using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;
    [SerializeField] private float destroyTimer;

    public Rigidbody2D rb;

    private Vector3 direction;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;

        Destroy(gameObject, destroyTimer);
    }

    void Update()
    {
        rb.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealth.instance.TakeDamage();

            Destroy(gameObject);
        }
    }
}
