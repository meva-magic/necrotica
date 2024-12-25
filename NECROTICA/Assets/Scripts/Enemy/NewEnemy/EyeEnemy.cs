using UnityEngine;
using UnityEngine.AI;

public class EyeEnemy : BaseEnemy
{
    [SerializeField] private GameObject projectilePrefab; // Префаб снаряда
    [SerializeField] private float projectileSpeed = 10f; // Скорость движения снаряда
    [SerializeField] private GameObject deathEffect;

    private void Awake()
    {
        health = 4f;
        damage = 10f; // Урон для EyeEnemy
        attackRange = 18f;
        attackCooldown = 2f;

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 3f; // Уникальная скорость EyeEnemy
        }
    }

    public override void Attack()
    {
        if (projectilePrefab != null && PlayerHealth.instance != null)
        {
            // Создаём снаряд
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Направляем снаряд в сторону игрока
            Vector3 direction = (PlayerHealth.instance.transform.position - transform.position).normalized;
            projectile.transform.forward = direction; // Устанавливаем направление снаряда

            // Задаём скорость снаряда
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = direction * projectileSpeed;
            }

            // Уничтожаем снаряд через 5 секунд
            Destroy(projectile, 5f);
        }
    }

    protected override void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("EyeEnemy уничтожен.");
        Destroy(gameObject);
    }
}
