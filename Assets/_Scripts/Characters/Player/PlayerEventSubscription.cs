using System.Collections;
using System.Collections.Generic;
using Component;
using UnityEngine;
namespace Player
{
    [RequireComponent(typeof(HealthComponent))]
    public class PlayerEventSubscription : MonoBehaviour
    {
        HealthComponent healthComponent;
        void Awake()
        {
            healthComponent = GetComponent<HealthComponent>();
            healthComponent.OnDied += OnDie;
        }
        void OnDie()
        {
            Logger.LogWarning("Player is dead");
        }
    }

}