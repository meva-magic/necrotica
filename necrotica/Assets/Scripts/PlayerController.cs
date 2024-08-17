using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;
    public float mouseSensetivity;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public static PlayerController instance;



    public int currentHealth;
    private int maxHealth = 100;

    private bool isDead = false;

    public GameObject deathScreen;



    void Start()
    {
        currentHealth = maxHealth;
    }



    private void Awake()
    {
        instance = this;
    }



    private void Update()
    {
        if(!isDead)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            //movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;

            rb.velocity = (moveHorizontal + moveVertical) * moveSpeed;


            //rotation
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensetivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
        }
    }



    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deathScreen.SetActive(true);
            isDead = true;
        }
    }



    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
