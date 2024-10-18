using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float awarenessRadius = 7;

    public bool isTriggered;


    private void Start()
    {
        player = FindFirstObjectByType<PlayerMove>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, player.position);

        if(dist < awarenessRadius)
        {
            isTriggered = true;
        }
    }
}
