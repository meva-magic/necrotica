using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffItem : MonoBehaviour
{
    protected Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected abstract void ApplyBuff(PlayerMove playerMove, PlayerHealth playerHealth);

    private void OnTriggerEnter(Collider other)
    {
        PlayerMove playerMove = other.GetComponent<PlayerMove>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerMove != null && playerHealth != null)
        {
            ApplyBuff(playerMove, playerHealth);
            AudioManager.instance.Play("BuffPickUp");
            if (animator != null)
            {
                animator.SetTrigger("Kury");
            }
            Destroy(gameObject);
        }
    }
}