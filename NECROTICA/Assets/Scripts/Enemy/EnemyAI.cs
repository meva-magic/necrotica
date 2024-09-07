using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyTrigger enemyTrigger;
    private Transform player;
    private NavMeshAgent enemyNavMesh;

    private void Start()
    {
        enemyTrigger = GetComponent<EnemyTrigger>();
        player = FindObjectOfType<PlayerMove>().transform;
        enemyNavMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(enemyTrigger.isTriggered)
        {
            enemyNavMesh.SetDestination(player.transform.position);
        }

        else
        {
            enemyNavMesh.SetDestination(transform.position);
        }
    }
}