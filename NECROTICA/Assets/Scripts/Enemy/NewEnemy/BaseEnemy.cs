/*using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float health = 10f; // Базовое здоровье
    public float damage = 10f; // Урон
    [SerializeField] private GameObject hitEffect;

    protected Transform player;
    protected NavMeshAgent agent;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        agent = GetComponent<NavMeshAgent>();
        Initialize();
    }

    // Инициализация в дочерних классах
    protected abstract void Initialize();

    public void TakeDamage(float damage)
    {
        health -= damage;

        // Проигрываем звук попадания
        AudioManager.instance.Play("EnemyHit");

        // Создаем визуальный эффект попадания
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
        // Удаляем противника из менеджера
        EnemyManager.instance.RemoveEnemy(this);

        // Восстанавливаем здоровье игроку
        PlayerHealth.instance.RestoreHealth(10);

        // Проигрываем звук смерти
        AudioManager.instance.Play("EnemyDeath");

        // Уничтожаем объект
        Destroy(gameObject);
    }
}*/
