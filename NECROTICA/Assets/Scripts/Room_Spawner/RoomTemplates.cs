using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] frontRooms;
    public GameObject[] backRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool lastRoom;
    public GameObject boos;

    void Update()
    {
        if (waitTime <= 0 && lastRoom == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(boos, rooms[i].transform.position, Quaternion.identity);
                    lastRoom = true;  // ”станавливаем, что последн€€ комната найдена и босс заспавнен
                }
            }
        }
        else if (!lastRoom)
        {
            waitTime -= Time.deltaTime;  // ”меньшаем waitTime только если lastRoom еще не найден
        }
    }
}
