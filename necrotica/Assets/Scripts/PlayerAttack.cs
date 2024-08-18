using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera viewCam;

    public GameObject Sword;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Sword.activeSelf == true)
        {
            Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {                
                if(hit.transform.tag == "Enemy")
                {
                    hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                }
            }
        }
    }
}
