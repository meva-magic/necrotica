using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public bool GotKey = false;

    private Shake shake;

    public SpriteRenderer rend;
    public GameObject effect;    
    public GameObject screenFlash;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shake.CamShake();
            AudioManager.instance.Play("KeyPickup");

            GameObject newScreenFlash = Instantiate(screenFlash, transform.position, transform.rotation) as GameObject;
           
            rend = newScreenFlash.GetComponent<SpriteRenderer>();
            StartCoroutine(Fade());
            Destroy(newScreenFlash, 2f);
            
            Destroy(gameObject);
            GotKey = true;
        }
    }

    IEnumerator Fade()
    {
        float alphaVal = rend.color.a;
        Color tmp = rend.color;

        while (rend.color.a < 1)
        {
            alphaVal -= 0.01f;
            tmp.a = alphaVal;
            rend.color = tmp;

            yield return new WaitForSeconds(0.06f);
        }
    }
}
