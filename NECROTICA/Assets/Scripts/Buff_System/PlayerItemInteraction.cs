using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemInteraction : MonoBehaviour
{
    [SerializeField] private Animator animator;  // Аниматор игрока

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (animator == null)
        {
            Debug.LogError("Animator is null. Cannot trigger animation.");
            return; // Остановить выполнение
        }

        if (other.CompareTag("Baff"))
        {
            PlayPickUpAnimation("Kury");
            Debug.Log("Attack animation triggered.");
        }
    }

    // Метод для воспроизведения анимации в зависимости от типа предмета
    private void PlayPickUpAnimation(string animationTrigger)
    {
        if (animator != null)
        {
            animator.SetTrigger(animationTrigger); // Применяем триггер для анимации
        }
    }
}
