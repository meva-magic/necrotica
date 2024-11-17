using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] frontRooms;
    public GameObject[] backRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;
    public GameObject nextRoom;
    public List<GameObject> rooms;

    public float waitTime; // Ожидание перед началом генерации
    private float replaceRoomTimer = 0f; // Таймер для замены комнат
    public float replaceRoomDuration = 2f; // Длительность замены комнаты

    private SpecialRoomSpawner specialRoomSpawner;

    public float specialRoomSpawnTimer = 8f; // Таймер для спауна специальных комнат
    private bool specialRoomsSpawned = false; // Флаг, чтобы спаунить специальные комнаты только один раз

    private void Start()
    {
        specialRoomSpawner = GetComponent<SpecialRoomSpawner>();
    }

    private void Update()
    {
        // Управление таймером замены комнат
        if (replaceRoomTimer > 0)
        {
            replaceRoomTimer -= Time.deltaTime;
            return;
        }

        // Управление генерацией
        if (waitTime <= 0)
        {
            if (rooms.Count < 14)
            {
                ReplaceLastRoomWithNextRoom();
            }
            else
            {
                HandleSpecialRoomSpawning();
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    // Логика замены последней комнаты
    private void ReplaceLastRoomWithNextRoom()
    {
        if (rooms.Count > 0)
        {
            GameObject currentLastRoom = rooms[rooms.Count - 1];
            if (currentLastRoom != null)
            {
                Vector3 lastRoomPosition = currentLastRoom.transform.position;
                Quaternion lastRoomRotation = currentLastRoom.transform.rotation;

                rooms.RemoveAt(rooms.Count - 1); // Удаляем из списка, но не уничтожаем сразу
                Destroy(currentLastRoom);

                GameObject newRoom = Instantiate(nextRoom, lastRoomPosition, lastRoomRotation);
                rooms.Add(newRoom);
            }
        }

        replaceRoomTimer = replaceRoomDuration;
    }

    // Управление спауном специальных комнат
    private void HandleSpecialRoomSpawning()
    {
        if (!specialRoomsSpawned)
        {
            // Уменьшаем таймер для специальных комнат
            specialRoomSpawnTimer -= Time.deltaTime;

            // Проверяем, истёк ли таймер
            if (specialRoomSpawnTimer <= 0)
            {
                specialRoomSpawner.SpawnSpecialRooms(rooms);
                specialRoomsSpawned = true; // Устанавливаем флаг, чтобы больше не спаунить специальные комнаты
            }
        }
    }
}
