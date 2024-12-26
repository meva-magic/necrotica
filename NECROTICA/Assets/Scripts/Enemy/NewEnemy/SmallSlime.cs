using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class SmallSlime : BaseEnemy
{
    [SerializeField] private GameObject deathEffect;

    private Animator animator; // Ссылка на Animator

    private void Awake()
    {
        // Устанавливаем уникальные параметры
        health = 2f;
        damage = 5f;
        attackRange = 4f;
        attackCooldown = 2f;

        // Устанавливаем скорость перемещения
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 3f; // Уникальная скорость SmallSlime
        }

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("Animator не найден на объекте EyeEnemy.");
        }
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);

        // Проигрываем анимацию получения урона
        if (animator != null)
        {
            animator.SetTrigger("TakeDamage");
        }

        // Проверяем, умер ли враг
        if (health <= 0)
        {
            Die();
        }
    }

    public override void Attack()
    {
        base.Attack(); // Воспроизведение общего звука атаки из BaseEnemy

    }

    protected override void Die()
    {
        PlayerHealth.instance.RestoreHealth(10);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("SmallSlime уничтожен.");
        Destroy(gameObject);
    }
}
