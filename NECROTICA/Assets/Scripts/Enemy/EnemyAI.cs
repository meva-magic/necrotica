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
        InitializeComponents();
    }

    private void Update()
    {
        if (player == null || baseEnemy == null || agent == null)
        {
            Debug.LogWarning("EnemyAI: Missing required components or references. Attempting to reinitialize.");
            InitializeComponents(); // Повторная попытка инициализации
            return;
        }

        HandleState();
        UpdateCooldown();
    }

    private void InitializeComponents()
    {
        // Ищем игрока
        var playerObject = Object.FindFirstObjectByType<PlayerMove>();
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("EnemyAI: Player not found in the scene.");
        }

        // Получаем необходимые компоненты
        agent = GetComponent<NavMeshAgent>();
        baseEnemy = GetComponent<BaseEnemy>();

        if (agent == null)
        {
            Debug.LogWarning("EnemyAI: NavMeshAgent is missing.");
        }
        if (baseEnemy == null)
        {
            Debug.LogWarning("EnemyAI: BaseEnemy component is missing.");
        }
    }

    private void HandleState()
    {
        if (player == null) return; // Если игрок отсутствует, пропускаем обработку

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
                    ChangeState(EnemyState.Idle);
                }
                else if (distanceToPlayer <= baseEnemy.attackRange)
                {
                    ChangeState(EnemyState.Attacking);
                }
                else
                {
                    ChasePlayer();
                }
                break;

            case EnemyState.Attacking:
                agent.isStopped = true;
                if (distanceToPlayer > baseEnemy.attackRange)
                {
                    agent.isStopped = false;
                    ChangeState(EnemyState.Chasing);
                }
                else if (attackCooldownTimer <= 0f)
                {
                    baseEnemy.Attack();
                    attackCooldownTimer = baseEnemy.attackCooldown;
                }
                break;
        }
    }

    private void ChasePlayer()
    {
        if (agent != null && !agent.isStopped)
        {
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
        currentState = newState;
    }
}
