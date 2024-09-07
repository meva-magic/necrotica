using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleToPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 targetPosition;
    private Vector3 targetDirection;

    [SerializeField] private float angle;


    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        targetDirection = targetPosition - transform.position;

        angle = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);
    }

    void OnGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, targetPosition);
    }
}
