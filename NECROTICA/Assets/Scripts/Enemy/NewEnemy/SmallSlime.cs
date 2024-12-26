using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class SmallSlime : BaseEnemy
{
    [SerializeField] private GameObject deathEffect;

    private Animator animator; // ������ �� Animator

    private void Awake()
    {
        // ������������� ���������� ���������
        health = 2f;
        damage = 5f;
        attackRange = 4f;
        attackCooldown = 2f;

        // ������������� �������� �����������
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 3f; // ���������� �������� SmallSlime
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("Animator �� ������ �� ������� EyeEnemy.");
        }
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);

        // ����������� �������� ��������� �����
        if (animator != null)
        {
            animator.SetTrigger("TakeDamage");
        }

        // ���������, ���� �� ����
        if (health <= 0)
        {
            Die();
        }
    }

    public override void Attack()
    {
        base.Attack(); // ��������������� ������ ����� ����� �� BaseEnemy

    }

    protected override void Die()
    {
        PlayerHealth.instance.RestoreHealth(10);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("SmallSlime ���������.");
        Destroy(gameObject);
    }
}
