using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour
{
    public float health = 10f; // Базовое здоровье
    public float damage = 10f; // Урон
    public NavMeshAgent agent;

    protected Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        agent = GetComponent<NavMeshAgent>();
        Initialize();
    }

    protected abstract void Initialize();

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    protected abstract void Die();
}
