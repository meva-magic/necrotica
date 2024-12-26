using UnityEngine;

public class BossEnemy : BaseEnemy
{
    [SerializeField] private GameObject bigSlimePrefab; // Префаб BigSlime
    [SerializeField] private GameObject deathEffect;    // Эффект смерти
    [SerializeField] private float spawnOffset = 1.5f;

    private void Awake()
    {
        health = 2f;
        damage = 10f;
        attackRange = 4f;
        attackCooldown = 3f;

        // Установить свойства NavMeshAgent
        var agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 2f; // Медленный, но мощный
        }
    }

    protected override void Die()
    {
        PlayerHealth.instance.RestoreHealth(20);
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        // Проверяем, чтобы префаб BigSlime был установлен
        if (bigSlimePrefab != null)
        {
            Vector3 spawnPosition1 = transform.position + new Vector3(-spawnOffset, 0f, 0f);
            Vector3 spawnPosition2 = transform.position + new Vector3(spawnOffset, 0f, 0f);

            // Создаём два BigSlime
            Instantiate(bigSlimePrefab, spawnPosition1, Quaternion.identity);
            Instantiate(bigSlimePrefab, spawnPosition2, Quaternion.identity);
        }

        // Уничтожаем объект босса
        Destroy(gameObject);
    }
}
