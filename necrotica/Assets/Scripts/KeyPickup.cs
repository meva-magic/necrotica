using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
     public bool GotKey = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AudioManager.instance.Play("KeyPickup");
            Destroy(gameObject);
            GotKey = true;
        }
    }
}
