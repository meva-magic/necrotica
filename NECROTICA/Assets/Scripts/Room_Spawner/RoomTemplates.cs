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
    private float replaceRoomTimer = 0f;
    public float replaceRoomDuration = 2f;

    private SpecialRoomSpawner specialRoomSpawner;

    private void Start()
    {
        specialRoomSpawner = GetComponent<SpecialRoomSpawner>();
    }

    private void Update()
    {
        if (replaceRoomTimer > 0)
        {
            replaceRoomTimer -= Time.deltaTime;
            return;
        }

        if (waitTime <= 0)
        {
            if (rooms.Count < 14)
            {
                ReplaceLastRoomWithNextRoom();
            }
            else
            {
                specialRoomSpawner.SpawnSpecialRooms(rooms);
            }
        }
        else
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

        replaceRoomTimer = replaceRoomDuration;
    }
}
