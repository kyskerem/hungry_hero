using Component;
using UnityEngine;
using UnityEngine.UI;


public class HungerBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private HungerComponent HungerComponent;
    void Awake()
    {
        HungerComponent.OnHungerChanged += ChangeHunger;
    }
    void ChangeHunger(float currentHunger, float maxHunger)
    {
        slider.value = currentHunger / maxHunger;
    }
}
