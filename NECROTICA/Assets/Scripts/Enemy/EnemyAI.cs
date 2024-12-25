using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private enum EnemyState
    {
        Idle,
        Chasing,
        Attacking
    }

    [SerializeField] private float awarenessRadius = 10f; // Радиус обнаружения игрока
    private EnemyState currentState = EnemyState.Idle;

    private Transform player;
    private NavMeshAgent agent;
    private BaseEnemy baseEnemy;

    private float attackCooldownTimer = 0f;

    private void Start()
    {
        player = Object.FindFirstObjectByType<PlayerMove>().transform;
        agent = GetComponent<NavMeshAgent>();
        baseEnemy = GetComponent<BaseEnemy>();
    }

    private void Update()
    {
        HandleState();
        UpdateCooldown();
    }

    private void HandleState()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case EnemyState.Idle:
                if (distanceToPlayer <= awarenessRadius)
                {

                    ChangeState(EnemyState.Chasing);
                }
                break;

            case EnemyState.Chasing:
                if (distanceToPlayer > awarenessRadius)
                {
                    // Если игрок вышел из зоны видимости, враг возвращается в Idle
                    ChangeState(EnemyState.Idle);
                }
                else if (distanceToPlayer <= baseEnemy.attackRange)
                {
                    // Если игрок в зоне атаки, переключаемся в Attacking
                    ChangeState(EnemyState.Attacking);
                }
                else
                {
                    // Иначе продолжаем преследовать игрока
                    ChasePlayer();
                }
                break;

            case EnemyState.Attacking:
                Debug.Log("Attacking player...");
                agent.isStopped = true;
                if (distanceToPlayer > baseEnemy.attackRange)
                {
                    // Если игрок вне радиуса атаки, возвращаемся к преследованию
                    agent.isStopped = false;
                    ChangeState(EnemyState.Chasing);
                }
                else if (attackCooldownTimer <= 0f)
                {
                    // Атакуем игрока
                    baseEnemy.Attack();
                    attackCooldownTimer = baseEnemy.attackCooldown;
                }
                break;
        }
    }

    private void ChasePlayer()
    {
        if (!agent.isStopped)
        {
            Debug.Log("Chasing player...");
            agent.SetDestination(player.position);
        }
    }

    private void UpdateCooldown()
    {
        if (attackCooldownTimer > 0f)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }

    private void ChangeState(EnemyState newState)
    {
        Debug.Log($"Changing state from {currentState} to {newState}");
        currentState = newState;
    }
}
