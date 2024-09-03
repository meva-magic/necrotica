using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public GameObject Sword;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AudioManager.instance.Play("Sword pickup");

            Destroy(gameObject);

            Sword.SetActive(true);
        }
    }
}
