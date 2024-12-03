using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomSpawner : MonoBehaviour
{
    public GameObject keykeeper; // Префаб ключника
    public GameObject bossPrefab; // Префаб босса
    public float spawnTimeout = 12f; // Таймер ожидания завершения спауна

    private bool bossSpawned = false; // Флаг, чтобы не спавнить босса повторно
    private bool keykeeperSpawned = false; // Флаг, чтобы не спавнить ключника повторно

    public void SpawnSpecialRooms(List<GameObject> rooms, RoomTemplates templates)
    {
        // Проверяем, достаточно ли комнат
        if (rooms.Count < 6) return;

        // Спавн ключника, если он ещё не создан
        if (!keykeeperSpawned && rooms.Count >= 6)
        {
            GameObject sixthRoom = rooms[5]; // Получаем 6-ю комнату
            if (sixthRoom != null)
            {
                // Выбор массива комнат ключника в зависимости от направления
                GameObject newRoomPrefab = null;
                if (sixthRoom.CompareTag("FrontRoom"))
                    newRoomPrefab = ChooseRandomRoom(templates.keykeeperFrontRooms);
                else if (sixthRoom.CompareTag("BackRoom"))
                    newRoomPrefab = ChooseRandomRoom(templates.keykeeperBackRooms);
                else if (sixthRoom.CompareTag("LeftRoom"))
                    newRoomPrefab = ChooseRandomRoom(templates.keykeeperLeftRooms);
                else if (sixthRoom.CompareTag("RightRoom"))
                    newRoomPrefab = ChooseRandomRoom(templates.keykeeperRightRooms);

                // Замена 6-й комнаты на новую
                if (newRoomPrefab != null)
                {
                    Vector3 roomPosition = sixthRoom.transform.position;
                    Quaternion roomRotation = sixthRoom.transform.rotation;

                    Destroy(sixthRoom); // Уничтожаем старую комнату
                    rooms[5] = Instantiate(newRoomPrefab, roomPosition, roomRotation); // Заменяем в списке

                    // Спавн ключника в новой комнате
                    Vector3 spawnPosition = roomPosition + new Vector3(2f, 0f, 0f);
                    Instantiate(keykeeper, spawnPosition, Quaternion.identity);

                    keykeeperSpawned = true;
                    Debug.Log("Keykeeper room spawned.");
                }
            }
        }

        // Спавн босса, если он ещё не создан
        if (!bossSpawned && rooms.Count >= 14)
        {
            GameObject lastRoom = rooms[rooms.Count - 1];
            if (lastRoom != null)
            {
                Debug.Log("Boss is being spawned.");
                SpawnBoss(lastRoom); // Спавним босса в последней комнате
                bossSpawned = true;
            }
        }

        // Запускаем проверку по таймеру
        StartCoroutine(CheckAndAssignBossRoom(rooms));
    }

    private void SpawnBoss(GameObject targetRoom)
    {
        Vector3 bossSpawnPosition = targetRoom.transform.position + Vector3.up * 2; // Поднятый уровень для босса
        Instantiate(bossPrefab, bossSpawnPosition, Quaternion.identity);
        Debug.Log("Boss spawned at position: " + bossSpawnPosition);
    }

    private IEnumerator CheckAndAssignBossRoom(List<GameObject> rooms)
    {
        yield return new WaitForSeconds(spawnTimeout); // Ожидаем окончания таймера

        // Если босс всё ещё не заспавнен, назначаем последнюю комнату комнатой босса
        if (!bossSpawned && rooms.Count > 0)
        {
            Debug.LogWarning("Spawn timeout reached. Assigning the last room as the boss room.");
            GameObject lastRoom = rooms[rooms.Count - 1];
            if (lastRoom != null)
            {
                SpawnBoss(lastRoom); // Спавним босса в последней комнате
                bossSpawned = true;
            }
        }
    }

    // Выбор случайной комнаты из массива
    private GameObject ChooseRandomRoom(GameObject[] roomArray)
    {
        if (roomArray.Length == 0) return null;
        int randomIndex = Random.Range(0, roomArray.Length);
        return roomArray[randomIndex];
    }
}
