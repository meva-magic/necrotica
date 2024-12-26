using UnityEngine;

public class BossEnemy : BaseEnemy
{
    [SerializeField] private GameObject bigSlimePrefab; // ������ BigSlime
    [SerializeField] private GameObject deathEffect;    // ������ ������
    [SerializeField] private float spawnOffset = 1.5f;

    private void Awake()
    {
        health = 2f;
        damage = 10f;
        attackRange = 4f;
        attackCooldown = 3f;

        // ���������� �������� NavMeshAgent
        var agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 2f; // ���������, �� ������
        }
    }

    protected override void Die()
    {
        PlayerHealth.instance.RestoreHealth(20);
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        // ���������, ����� ������ BigSlime ��� ����������
        if (bigSlimePrefab != null)
        {
            Vector3 spawnPosition1 = transform.position + new Vector3(-spawnOffset, 0f, 0f);
            Vector3 spawnPosition2 = transform.position + new Vector3(spawnOffset, 0f, 0f);

            // ������ ��� BigSlime
            Instantiate(bigSlimePrefab, spawnPosition1, Quaternion.identity);
            Instantiate(bigSlimePrefab, spawnPosition2, Quaternion.identity);
        }

        // ���������� ������ �����
        Destroy(gameObject);
    }
}
