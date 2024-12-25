using UnityEngine;
using UnityEngine.AI;

public class SmallSlime : BaseEnemy
{
    [SerializeField] private GameObject deathEffect;

    private void Awake()
    {
        // Устанавливаем уникальные параметры
        health = 4f;
        damage = 5f;
        attackRange = 4f;
        attackCooldown = 2f;

        // Устанавливаем скорость перемещения
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 3f; // Уникальная скорость SmallSlime
        }
    }

    protected override void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("SmallSlime уничтожен.");
        Destroy(gameObject);
    }
}
