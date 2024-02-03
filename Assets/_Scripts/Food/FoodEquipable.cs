using Component;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class FoodEquipable : MonoBehaviour
{
    [SerializeField] private int saturation;
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            other.TryGetComponent(out HungerComponent hungerComponent);
            other.TryGetComponent(out HealthComponent healthComponent);
            healthComponent.Heal(5);
            hungerComponent.IncreaseHunger(saturation);
            Destroy(gameObject, .1f);
        }
    }
}
