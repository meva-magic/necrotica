using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomSpawner : MonoBehaviour
{
    public GameObject keykeeper; // ������ ��������
    public GameObject bossPrefab; // ������ �����
    public float spawnTimeout = 12f; // ������ �������� ���������� ������

    private bool bossSpawned = false; // ����, ����� �� �������� ����� ��������
    private bool keykeeperSpawned = false; // ����, ����� �� �������� �������� ��������

    public void SpawnSpecialRooms(List<GameObject> rooms, RoomTemplates templates)
    {
        // ���������, ���������� �� ������
        if (rooms.Count < 6) return;

        // ����� ��������, ���� �� ��� �� ������
        if (!keykeeperSpawned && rooms.Count >= 6)
        {
            GameObject sixthRoom = rooms[5]; // �������� 6-� �������
            if (sixthRoom != null)
            {
                // ����� ������� ������ �������� � ����������� �� �����������
                GameObject newRoomPrefab = null;
                if (sixthRoom.CompareTag("FrontRoom"))
                    newRoomPrefab = ChooseRandomRoom(templates.keykeeperFrontRooms);
                else if (sixthRoom.CompareTag("BackRoom"))
                    newRoomPrefab = ChooseRandomRoom(templates.keykeeperBackRooms);
                else if (sixthRoom.CompareTag("LeftRoom"))
                    newRoomPrefab = ChooseRandomRoom(templates.keykeeperLeftRooms);
                else if (sixthRoom.CompareTag("RightRoom"))
                    newRoomPrefab = ChooseRandomRoom(templates.keykeeperRightRooms);

                // ������ 6-� ������� �� �����
                if (newRoomPrefab != null)
                {
                    Vector3 roomPosition = sixthRoom.transform.position;
                    Quaternion roomRotation = sixthRoom.transform.rotation;

                    Destroy(sixthRoom); // ���������� ������ �������
                    rooms[5] = Instantiate(newRoomPrefab, roomPosition, roomRotation); // �������� � ������

                    // ����� �������� � ����� �������
                    Vector3 spawnPosition = roomPosition + new Vector3(2f, 0f, 0f);
                    Instantiate(keykeeper, spawnPosition, Quaternion.identity);

                    keykeeperSpawned = true;
                    Debug.Log("Keykeeper room spawned.");
                }
            }
        }

        // ����� �����, ���� �� ��� �� ������
        if (!bossSpawned && rooms.Count >= 14)
        {
            GameObject lastRoom = rooms[rooms.Count - 1];
            if (lastRoom != null)
            {
                Debug.Log("Boss is being spawned.");
                SpawnBoss(lastRoom); // ������� ����� � ��������� �������
                bossSpawned = true;
            }
        }

        // ��������� �������� �� �������
        StartCoroutine(CheckAndAssignBossRoom(rooms));
    }

    private void SpawnBoss(GameObject targetRoom)
    {
        Vector3 bossSpawnPosition = targetRoom.transform.position + Vector3.up * 2; // �������� ������� ��� �����
        Instantiate(bossPrefab, bossSpawnPosition, Quaternion.identity);
        Debug.Log("Boss spawned at position: " + bossSpawnPosition);
    }

    private IEnumerator CheckAndAssignBossRoom(List<GameObject> rooms)
    {
        yield return new WaitForSeconds(spawnTimeout); // ������� ��������� �������

        // ���� ���� �� ��� �� ���������, ��������� ��������� ������� �������� �����
        if (!bossSpawned && rooms.Count > 0)
        {
            Debug.LogWarning("Spawn timeout reached. Assigning the last room as the boss room.");
            GameObject lastRoom = rooms[rooms.Count - 1];
            if (lastRoom != null)
            {
                SpawnBoss(lastRoom); // ������� ����� � ��������� �������
                bossSpawned = true;
            }
        }
    }

    // ����� ��������� ������� �� �������
    private GameObject ChooseRandomRoom(GameObject[] roomArray)
    {
        if (roomArray.Length == 0) return null;
        int randomIndex = Random.Range(0, roomArray.Length);
        return roomArray[randomIndex];
    }
}
