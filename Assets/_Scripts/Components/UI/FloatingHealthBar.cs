using Component;
using UnityEngine;
using UnityEngine.UI;


public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private bool showAtBeginning = false;
    private bool isActive;
    void Awake()
    {
        healthComponent.OnHealthChanged += ChangeHealth;
        gameObject.SetActive(showAtBeginning);
        isActive = showAtBeginning;
    }
    void ChangeHealth(float currentHealth, float maxHealth)
    {
        // don't show if enemy is not damaged
        if (!isActive && currentHealth != maxHealth)
        {
            isActive = true;
            gameObject.SetActive(true);
        }
        slider.value = currentHealth / maxHealth;
    }
}
