using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    public float health;

    [SerializeField] public float maxArmor = 100f;
    [SerializeField] private float armor;

    public bool playerIsDead;
    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
        //health = Mathf.CeilToInt(maxHealth * 0.5f);
        armor = 0;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
        }
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
                float remainingDamage = damage - armor;
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
