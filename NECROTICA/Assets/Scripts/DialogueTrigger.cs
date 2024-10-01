using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject Dialogue;
    private Shake shake;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //shake.CamShake();
            //AudioManager.instance.Play("Sword pickup");
            Dialogue.SetActive(true);
        }
    }
}
