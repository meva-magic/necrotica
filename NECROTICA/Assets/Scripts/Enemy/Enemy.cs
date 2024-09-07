using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyHealth = 2f;
    [SerializeField] GameObject swordHitEffect;

    [SerializeField] EnemyManager enemyManager;


    public void TakeDamage(float damage)
    {
        //enemyHealth -= damage;
        AudioManager.instance.Play("EnemyHit");
        Instantiate(swordHitEffect, transform.position, Quaternion.identity);

        if(enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);

            AudioManager.instance.Play("EnemyDeath");
            Destroy(gameObject);
        }
    }
}
