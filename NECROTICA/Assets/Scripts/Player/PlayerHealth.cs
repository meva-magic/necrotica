using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 10;
    [SerializeField] public int health;

    [SerializeField] public int maxArmor = 10;
    [SerializeField] private int armor;

    public bool playerIsDead;

    private void Start()
    {
        health = Mathf.CeilToInt(maxHealth * 0.5f);
        armor = 0;

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

    
    public void RestoreHealth(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
    }

    public void RestoreArmor(int amount)
    {
        armor = Mathf.Min(armor + amount, maxArmor);
    }
}
