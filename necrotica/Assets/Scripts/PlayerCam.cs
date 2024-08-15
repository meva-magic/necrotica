using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float MouseSensetivity;

    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start()
    {

    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 

        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * MouseSensetivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * MouseSensetivity;

        yRotation += mouseX;
        //xRotation += mouseY;

        //yRotation = Mathf.Clamp(yRotation, 90, -90);

        //rotation
        transform.rotation = Quaternion.Euler(yRotation, 90, -90);
        //orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
