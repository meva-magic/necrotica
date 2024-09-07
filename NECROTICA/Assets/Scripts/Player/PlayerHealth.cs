using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int health;

    [SerializeField] private int maxArmor = 3;
    private int armor;

    public bool playerIsDead;

    private void Start()
    {
        health = maxHealth;
        armor = maxArmor;
    }

    private void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        if(armor > 0)
        {
            if(armor >= damage)
            {
                armor -= damage;
            }

            else if(armor < damage)
            {
                int remainingDamage = damage - armor;
                armor = 0;

                health -= remainingDamage;
            }
        }

        else
        {
            health -= damage;
        }

        if(health <= 0)
        {
            playerIsDead = true;
            UIManager.instance.GameOver();
        }
    }
}
