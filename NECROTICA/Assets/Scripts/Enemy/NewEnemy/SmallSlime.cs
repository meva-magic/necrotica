using UnityEngine;

public class SmallSlime : BaseEnemy
{
    protected override void Initialize() { }

    private void Update()
    {
        agent.SetDestination(player.position);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
