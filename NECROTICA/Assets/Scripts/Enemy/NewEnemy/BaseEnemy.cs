/*using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float health = 10f; // ������� ��������
    public float damage = 10f; // ����
    [SerializeField] private GameObject hitEffect;

    protected Transform player;
    protected NavMeshAgent agent;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        agent = GetComponent<NavMeshAgent>();
        Initialize();
    }

    // ������������� � �������� �������
    protected abstract void Initialize();

    public void TakeDamage(float damage)
    {
        health -= damage;

        // ����������� ���� ���������
        AudioManager.instance.Play("EnemyHit");

        // ������� ���������� ������ ���������
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // ������� ���������� �� ���������
        EnemyManager.instance.RemoveEnemy(this);

        // ��������������� �������� ������
        PlayerHealth.instance.RestoreHealth(10);

        // ����������� ���� ������
        AudioManager.instance.Play("EnemyDeath");

        // ���������� ������
        Destroy(gameObject);
    }
}*/
