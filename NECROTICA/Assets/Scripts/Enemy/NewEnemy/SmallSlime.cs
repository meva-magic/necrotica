using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class SmallSlime : BaseEnemy
{
    [SerializeField] private GameObject deathEffect;

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
    }

    public override void Attack()
    {
        base.Attack(); // ��������������� ������ ����� ����� �� BaseEnemy

    }

    protected override void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("SmallSlime ���������.");
        Destroy(gameObject);
    }
}
