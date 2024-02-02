using System.Collections;
using System.Collections.Generic;
using Component;
using UnityEngine;
using UnityEngine.UI;


public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private HealthComponent healthComponent;
    void Awake()
    {
        healthComponent.OnHealthChanged += ChangeHealth;
    }
    void ChangeHealth(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth;
    }
}
