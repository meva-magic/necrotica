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

    public float waitTime;
    public float bossRoomWaitTime;
    private bool bossRoomSpawned;
    public GameObject bossRoom;

    private float replaceRoomTimer = 0f; // Таймер задержки перед запуском Update
    public float replaceRoomDuration = 2f; // Длительность таймера

    private void Update()
    {
        // Если таймер задержки активен, уменьшаем его и не запускаем остальную логику Update
        if (replaceRoomTimer > 0)
        {
            replaceRoomTimer -= Time.deltaTime;
            return;
        }

        if (waitTime <= 0 && !bossRoomSpawned)
        {
            if (rooms.Count < 14)
            {
                ReplaceLastRoomWithNextRoom();
            }
            else
            {
                if (bossRoomWaitTime <= 0)
                {
                    SpawnBossRoom();
                }
                else
                {
                    bossRoomWaitTime -= Time.deltaTime;
                }
            }
        }
        else if (!bossRoomSpawned)
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void ReplaceLastRoomWithNextRoom()
    {
        if (rooms.Count > 0)
        {
            GameObject currentLastRoom = rooms[rooms.Count - 1];
            Vector3 lastRoomPosition = currentLastRoom.transform.position;
            Quaternion lastRoomRotation = currentLastRoom.transform.rotation;

            Destroy(currentLastRoom);
            rooms.RemoveAt(rooms.Count - 1);

            GameObject newRoom = Instantiate(nextRoom, lastRoomPosition, lastRoomRotation);
            rooms.Add(newRoom);
        }

        // Запускаем таймер задержки
        replaceRoomTimer = replaceRoomDuration;
    }

    private void SpawnBossRoom()
    {
        if (rooms.Count > 0)
        {
            GameObject lastRoom = Instantiate(bossRoom, rooms[rooms.Count - 1].transform.position, rooms[rooms.Count - 1].transform.rotation);
            rooms.Add(lastRoom);
            bossRoomSpawned = true; // Устанавливаем флаг для предотвращения повторного создания
        }
    }
}
