/*using System.Collections;
using UnityEngine;

public class EyeEnemy : BaseEnemy
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootDelay = 3f;

    protected override void Initialize()
    {
        health = 15f;
        damage = 10f;
        StartCoroutine(ShootAtPlayer());
    }

    private IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDelay);

            if (Vector3.Distance(transform.position, player.position) <= 10f)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.linearVelocity = (player.position - transform.position).normalized * 10f;
            Destroy(projectile, 5f);
        }
    }
}*/
