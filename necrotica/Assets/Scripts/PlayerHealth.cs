using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath; //action delegate returns void and doesnt take parametres

    public int currentHealth;
    private int maxHealth = 1;

    private bool isDead;

    public static PlayerHealth instance;

    void Start()
    {
        currentHealth = maxHealth;
    }


    private void Awake()
    {
        instance = this;
    }


    public void TakeDamage()
    {
        OnPlayerDeath?.Invoke();
        /*
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
        */
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
