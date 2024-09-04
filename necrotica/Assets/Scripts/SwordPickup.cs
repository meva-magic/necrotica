using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public GameObject Sword;

    private Shake shake;
    private GameObject flashPoint;

    public SpriteRenderer rend;
    public GameObject effect;    
    public GameObject screenFlash;

    void Start()
    {
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        flashPoint = GameObject.FindGameObjectWithTag("FlashPoint");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //shake.CamShake();
            AudioManager.instance.Play("Sword pickup");
            Destroy(gameObject, 6f);

            GameObject newScreenFlash = Instantiate(screenFlash, flashPoint.transform.position, transform.rotation) as GameObject;
           
            rend = newScreenFlash.GetComponent<SpriteRenderer>();
            StartCoroutine(Fade());
            Destroy(newScreenFlash, 6f);

            Sword.SetActive(true);
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
