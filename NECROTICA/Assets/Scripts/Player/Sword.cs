using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private BoxCollider swordTrigger;
    public EnemyManager enemyManager;

    [SerializeField] private float range = 10f;
    [SerializeField] private float verticalRange = 10f;
    [SerializeField] private float damage = 2f;
    
    [SerializeField] private float hitRate;
    [SerializeField] private float nextTimeToHit;

    [SerializeField] private LayerMask raycastLayerMask;

    private void Start()
    {
        swordTrigger = GetComponent<BoxCollider>();
        swordTrigger.size = new Vector3(2, verticalRange, range);
        swordTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > nextTimeToHit)
        {
            Hit();
        }
    }

    private void Hit()
    {
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;

            if(Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if(hit.transform == enemy.transform)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }

        nextTimeToHit = Time.time + hitRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if(enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if(enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
