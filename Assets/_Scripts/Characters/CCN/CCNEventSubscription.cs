using Component;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class CCNEventSubscription : MonoBehaviour
{
    HealthComponent healthComponent;
    void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.OnDied += OnDie;
    }
    void OnDie()
    {
        Logger.LogWarning("a CNN died here");
    }
}
