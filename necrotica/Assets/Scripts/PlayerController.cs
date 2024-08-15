using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D rb;

    public float MoveSpeed = 6f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public Camera viewCam;

    void Start()
    {

    }

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;

        rb.velocity = (moveHorizontal + moveVertical) * MoveSpeed;



        //mouseInput = new Vector2 (Input.GetAxisRaw("Mouse X") * MouseSensetivity, 0f);

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

        //viewCam.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));



        //punching
        if(Input.GetMouseButton(0))
        {
            Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Ememy")
                {
                    hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                }
            }
            //else{Debug.Log("im looking at nothing");}
        }
    }
}
