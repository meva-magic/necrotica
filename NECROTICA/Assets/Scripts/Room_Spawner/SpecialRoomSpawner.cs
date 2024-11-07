using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomSpawner : MonoBehaviour
{
    public GameObject bossRoom;
    public GameObject keykeeper;        
    private bool bossRoomSpawned = false; // Флаг, чтобы не спавнить босса повторно
    private bool keykeeperSpawned = false; // Флаг, чтобы не спавнить ключника повторно

    public void SpawnSpecialRooms(List<GameObject> rooms)
    {

        if (!keykeeperSpawned && rooms.Count >= 6)
        {
            GameObject seventhRoom = rooms[rooms.Count - 9]; 
            Instantiate(keykeeper, seventhRoom.transform.position, Quaternion.identity);
            keykeeperSpawned = true;
        }

        if (!bossRoomSpawned && rooms.Count >= 14)
        {
            GameObject lastRoom = rooms[rooms.Count - 1];
            Instantiate(bossRoom, lastRoom.transform.position, Quaternion.identity);
            bossRoomSpawned = true;
        }
    }
}
