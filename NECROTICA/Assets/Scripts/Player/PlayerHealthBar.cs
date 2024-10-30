using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider healthSliderDelay;

    private float lerpSpeed = 0.03f;

    private void Start()
    {
        healthSlider.value = 1;
        healthSliderDelay.value = 1;
    }

    private void Update()
    {
        if(healthSlider.value != PlayerHealth.instance.health / 100)
        {
            healthSlider.value = PlayerHealth.instance.health / 100;
        }

        if(healthSlider.value != healthSliderDelay.value)
        {
            healthSliderDelay.value = Mathf.Lerp(healthSliderDelay.value,  (PlayerHealth.instance.health / 100), lerpSpeed);
        }
    }
}
