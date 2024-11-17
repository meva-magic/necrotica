using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomSpawner : MonoBehaviour
{
    public GameObject bossRoom;
    public GameObject keykeeper;
    public float spawnTimeout = 12f; // ������ �������� ���������� ������
    private bool bossRoomSpawned = false; // ����, ����� �� �������� ����� ��������
    private bool keykeeperSpawned = false; // ����, ����� �� �������� �������� ��������

    public void SpawnSpecialRooms(List<GameObject> rooms)
    {
        // ���������, ���������� �� ������
        if (rooms.Count < 6) return;

        // ����� ��������, ���� �� ��� �� ������
        if (!keykeeperSpawned && rooms.Count >= 6)
        {
            GameObject sixthRoom = rooms[5]; // �������� 6-� �������
            if (sixthRoom != null)
            {
                Debug.Log("Keykeeper room is being created.");
                Vector3 spawnPosition = sixthRoom.transform.position + new Vector3(2f, 0f, 0f); 
                Instantiate(keykeeper, spawnPosition, Quaternion.identity);
                Debug.Log("Keykeeper room is being created.");
                keykeeperSpawned = true;
            }
        }

        // ����� ������� �����, ���� ��� ��� �� �������
        if (!bossRoomSpawned && rooms.Count >= 14)
        {
            GameObject lastRoom = rooms[rooms.Count - 1];
            if (lastRoom != null)
            {
                Instantiate(bossRoom, lastRoom.transform.position, Quaternion.identity);
                bossRoomSpawned = true;
            }
        }

        // ��������� �������� �� �������
        StartCoroutine(CheckAndAssignBossRoom(rooms));
    }

    private IEnumerator CheckAndAssignBossRoom(List<GameObject> rooms)
    {
        yield return new WaitForSeconds(spawnTimeout); // ������� ��������� �������

        // ���� ���� �� ��� �� ���������, ��������� ��������� ������� �������� �����
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
