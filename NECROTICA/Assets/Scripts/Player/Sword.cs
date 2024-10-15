using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private BoxCollider swordTrigger;
    public EnemyManager enemyManager;

    [SerializeField] private float range = 3f;
    [SerializeField] private float verticalRange = 3f;
    [SerializeField] public float damage = 2f;
    
    [SerializeField] private float hitRate;
    [SerializeField] private float hitRadius = 3f;
    [SerializeField] private float nextTimeToHit;

    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;

    private void Start()
    {
        swordTrigger = GetComponent<BoxCollider>();
        swordTrigger.size = new Vector3(1.5f, verticalRange, range);
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
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, hitRadius, enemyLayerMask);

        foreach(var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyTrigger>().isTriggered = true;
        }
        
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

                else
                {
                    AudioManager.instance.Play("SwordSwoosh");
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
