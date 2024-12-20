using UnityEngine;

public class RedKeyPickup : MonoBehaviour
{
    public float activationDistance = 2f;
    private GameObject player;
    private PickupManager pickupManager;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pickupManager = Object.FindFirstObjectByType<PickupManager>();

        if (pickupManager == null)
        {
            Debug.LogError("PickupManager не найден в сцене!");
        }
    }

    void Update()
    {
        if (player == null || pickupManager == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= activationDistance && Input.GetKeyDown(KeyCode.Space))
        {
            ActivatePickup();
        }
    }

    void ActivatePickup()
    {
        Debug.Log("RedKey поднят!");
        pickupManager.redKeyPickedUp = true;
        Destroy(gameObject); // Удаляем объект после активации
    }
}
