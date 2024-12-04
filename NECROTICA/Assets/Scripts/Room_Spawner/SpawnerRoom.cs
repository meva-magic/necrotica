using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRoom : MonoBehaviour
{
    public int openingDirection;
    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;
    public float waitTime = 10;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (!spawned)
        {
            if (templates.rooms.Count < 14)
            {
                SpawnRegularRoom();
            }
            else if (templates.rooms.Count == 14)
            {
                SpawnBossRoom();
            }
        }
    }

    void SpawnRegularRoom()
    {
        if (openingDirection == 1)
        {
            rand = Random.Range(0, templates.frontRooms.Length);
            Instantiate(templates.frontRooms[rand], transform.position, templates.frontRooms[rand].transform.rotation);
        }
        else if (openingDirection == 2)
        {
            rand = Random.Range(0, templates.rightRooms.Length);
            Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
        }
        else if (openingDirection == 3)
        {
            rand = Random.Range(0, templates.backRooms.Length);
            Instantiate(templates.backRooms[rand], transform.position, templates.backRooms[rand].transform.rotation);
        }
        else if (openingDirection == 4)
        {
            rand = Random.Range(0, templates.leftRooms.Length);
            Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
        }

        spawned = true;
    }

    void SpawnBossRoom()
    {
        if (openingDirection == 1)
        {
            rand = Random.Range(0, templates.bossFrontRooms.Length);
            Instantiate(templates.bossFrontRooms[rand], transform.position, templates.bossFrontRooms[rand].transform.rotation);
        }
        else if (openingDirection == 2)
        {
            rand = Random.Range(0, templates.bossRightRooms.Length);
            Instantiate(templates.bossRightRooms[rand], transform.position, templates.bossRightRooms[rand].transform.rotation);
        }
        else if (openingDirection == 3)
        {
            rand = Random.Range(0, templates.bossBackRooms.Length);
            Instantiate(templates.bossBackRooms[rand], transform.position, templates.bossBackRooms[rand].transform.rotation);
        }
        else if (openingDirection == 4)
        {
            rand = Random.Range(0, templates.bossLeftRooms.Length);
            Instantiate(templates.bossLeftRooms[rand], transform.position, templates.bossLeftRooms[rand].transform.rotation);
        }

        spawned = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            SpawnerRoom otherSpawner = other.GetComponent<SpawnerRoom>();
            if (otherSpawner != null)
            {
                if (!otherSpawner.spawned && !spawned)
                {
                    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                }
                if (otherSpawner.spawned && !spawned)
                {
                    Destroy(gameObject);
                }
            }
        }

        spawned = true;
    }
}
