/*using UnityEngine;

public class BigSlime : BaseEnemy
{
    [SerializeField] private GameObject smallSlimePrefab;

    protected override void Initialize()
    {
        health = 50f;
        damage = 10f;
    }

    private void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    protected override void Die()
    {
        base.Die();

        // Спавним маленьких слизней
        if (smallSlimePrefab != null)
        {
            Instantiate(smallSlimePrefab, transform.position + Vector3.left, Quaternion.identity);
            Instantiate(smallSlimePrefab, transform.position + Vector3.right, Quaternion.identity);
        }
    }
}*/
