using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    private int maxHealth = 100;

    private bool isDead;

    public GameObject deathScreen;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deathScreen.SetActive(true);
            isDead = true;
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
