using System.Collections;
using UnityEngine;

public class EyeEnemy : BaseEnemy
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootDelay = 3f;

    protected override void Initialize()
    {
        StartCoroutine(ShootAtPlayer());
    }

    private IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDelay);

            if (Vector3.Distance(transform.position, player.position) <= 10f) // ��������� �����
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.linearVelocity = (player.position - transform.position).normalized * 10f; // �������� �������
        Destroy(projectile, 5f); // ���������� ������ ����� 5 ������

        PlayerHealth.instance.TakeDamage((int)damage);
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
