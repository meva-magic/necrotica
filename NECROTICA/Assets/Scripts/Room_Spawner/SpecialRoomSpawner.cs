using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomSpawner : MonoBehaviour
{
    public GameObject bossRoom;
    public GameObject keykeeper;
    public float spawnTimeout = 12f; // Таймер ожидания завершения спауна
    private bool bossRoomSpawned = false; // Флаг, чтобы не спавнить босса повторно
    private bool keykeeperSpawned = false; // Флаг, чтобы не спавнить ключника повторно

    public void SpawnSpecialRooms(List<GameObject> rooms)
    {
        // Проверяем, достаточно ли комнат
        if (rooms.Count < 6) return;

        // Спавн ключника, если он ещё не создан
        if (!keykeeperSpawned && rooms.Count >= 6)
        {
            GameObject sixthRoom = rooms[5]; // Получаем 6-ю комнату
            if (sixthRoom != null)
            {
                Debug.Log("Keykeeper room is being created.");
                Vector3 spawnPosition = sixthRoom.transform.position + new Vector3(2f, 0f, 0f); 
                Instantiate(keykeeper, spawnPosition, Quaternion.identity);
                Debug.Log("Keykeeper room is being created.");
                keykeeperSpawned = true;
            }
        }

        // Спавн комнаты босса, если она ещё не создана
        if (!bossRoomSpawned && rooms.Count >= 14)
        {
            GameObject lastRoom = rooms[rooms.Count - 1];
            if (lastRoom != null)
            {
                Instantiate(bossRoom, lastRoom.transform.position, Quaternion.identity);
                bossRoomSpawned = true;
            }
        }

        // Запускаем проверку по таймеру
        StartCoroutine(CheckAndAssignBossRoom(rooms));
    }

    private IEnumerator CheckAndAssignBossRoom(List<GameObject> rooms)
    {
        yield return new WaitForSeconds(spawnTimeout); // Ожидаем окончания таймера

        // Если босс всё ещё не заспавнен, назначаем последнюю комнату комнатой босса
        if (!bossRoomSpawned && rooms.Count > 0)
        {
            Debug.LogWarning("Spawn timeout reached. Assigning the last room as the boss room.");

            GameObject lastRoom = rooms[rooms.Count - 1];
            if (lastRoom != null)
            {
                Instantiate(bossRoom, lastRoom.transform.position, Quaternion.identity);
                bossRoomSpawned = true;
            }
        }
    }
}
