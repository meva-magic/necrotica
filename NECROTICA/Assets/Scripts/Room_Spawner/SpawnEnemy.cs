using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // ������ �����

    private void OnEnable()
    {
        // ������� ����� ����� ��� ��������� �����
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        if (enemyPrefab != null)
        {
            // ������� ����� �� ����� ����� ������
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Enemy prefab is not assigned in SpawnPoint!");
        }

        // ���������� ������ ����� ������
        Destroy(gameObject);
    }
}
