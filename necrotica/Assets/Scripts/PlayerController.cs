using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;
    public float mouseSensetivity;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public static PlayerController instance;

    public Animator anim;


    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= DisablePlayerMovement;
    }


    private void Start()
    {
        EnablePlayerMovement();
    }


    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
            //movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;

            rb.velocity = (moveHorizontal + moveVertical) * moveSpeed;


            //rotation
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensetivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            if(moveInput != Vector2.zero)
            {
                anim.SetBool("isMoving", true);
                //AudioManager.instance.Play("Footsteps");
            }
            
            else
            {
                anim.SetBool("isMoving", false);
                //AudioManager.instance.Stop("Footsteps");
            }
    }


    private void EnablePlayerMovement()
    {
        //animator.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void DisablePlayerMovement()
    {
        //animator.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
