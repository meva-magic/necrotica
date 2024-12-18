using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemInteraction : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem particleEffect;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (animator == null)
        {
            //Debug.LogError("Animator is null. Cannot trigger animation.");
            return; // Остановить выполнение
        }

        if (other.CompareTag("Baff"))
        {
            PlayPickUpAnimation("Kury");
            TriggerParticleEffect();
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

    // Метод для активации Particle System
    private void TriggerParticleEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.Play(); // Запускаем эффект
        }
    }
}
