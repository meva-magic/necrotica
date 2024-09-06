using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyHealth = 2f;

    [SerializeField] EnemyManager enemyManager;


    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;

        if(enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }
}
