using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // Уменьшаем скорость
    private float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play("SwordSwoosh");
            Debug.Log("Попал снарядом.");
            PlayerHealth.instance.TakeDamage((int)damage);
            Destroy(gameObject);
        }
    }
}
