using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SpawnerRoom : MonoBehaviour
{
    public int openingDirection;
    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if (spawned == false)
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
    }

    void OnTriggerEnter3D(Collider other)
    {
            if (other.CompareTag("SpawnPoint") && other.GetComponent<SpawnerRoom>().spawned == true)
            {
                Destroy(gameObject);
            }
    }
}
