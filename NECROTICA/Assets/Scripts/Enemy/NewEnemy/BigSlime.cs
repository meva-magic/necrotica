using System.Collections;
using UnityEngine;

public class BigSlime : BaseEnemy
{
    [SerializeField] private GameObject smallSlimePrefab;

    protected override void Initialize() { }

    private void Update()
    {
        agent.SetDestination(player.position);
    }

    protected override void Die()
    {
        // ������� ��������� �������
        Instantiate(smallSlimePrefab, transform.position + Vector3.left, Quaternion.identity);
        Instantiate(smallSlimePrefab, transform.position + Vector3.right, Quaternion.identity);

        Destroy(gameObject);
    }
}
