using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float lowerDistance = 3f; // Расстояние, на которое дверь опустится вниз
    [SerializeField] private float lowerSpeed = 2f; // Скорость, с которой дверь опускается
    [SerializeField] private float activationDistance = 2f; // Расстояние для активации двери
    [SerializeField] private KeyCode activationKey = KeyCode.Space; // Клавиша для активации

    private Vector3 initialPosition; // Начальная позиция двери
    private Vector3 targetPosition; // Позиция, до которой дверь опустится
    private bool isLowering = false; // Состояние опускания двери
    private Collider doorCollider; // Коллайдер двери

    void Start()
    {
        // Сохранение начальной позиции двери
        initialPosition = transform.position;
        // Расчет целевой позиции двери
        targetPosition = initialPosition - new Vector3(0, lowerDistance, 0);
        // Получение коллайдера двери
        doorCollider = GetComponent<Collider>();
        if (doorCollider == null)
        {
            Debug.LogError("Коллайдер двери не найден!");
        }
    }

    void Update()
    {
        // Проверяем расстояние до игрока
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Если игрок находится в зоне активации и нажимает клавишу, начинаем опускать дверь
        if (distanceToPlayer <= activationDistance && Input.GetKeyDown(activationKey) && !isLowering)
        {
            isLowering = true;
            if (doorCollider != null)
            {
                doorCollider.enabled = false; // Отключаем коллайдер двери
            }
        }

        // Если дверь опускается, перемещаем ее вниз
        if (isLowering)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, lowerSpeed * Time.deltaTime);

            // Если достигли целевой позиции, прекращаем опускание
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isLowering = false;
            }
        }
    }
}
