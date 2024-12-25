using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [Header("Base Stats")]
    public float health = 10f;         // ��������
    public float damage = 5f;          // ����
    public float attackRange = 2f;     // ������ �����
    public float attackCooldown = 3f; // ������� �����

    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log($"{gameObject.name} ������� ����, �������� {health} HP.");

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Attack()

    {
        Debug.Log($"{gameObject.name} ������� ������ � ������� {damage} �����!");
        PlayerHealth.instance.TakeDamage((int)damage);
    }

    protected abstract void Die(); // ������ ������ ��� ���������� ������
}
