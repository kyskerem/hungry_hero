using System;
using UnityEngine;

namespace Component
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 30f;
        public event Action<float> OnHealthChanged;
        public event Action OnDied;
        private float health;
        void Awake()
        {
            health = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0) OnDie();
            OnHealthChange();
            Logger.LogWarning($"health: {health}");

        }
        void OnDie()
        {
            OnDied?.Invoke();
        }
        void OnHealthChange()
        {
            OnHealthChanged?.Invoke(health);
        }
    }
}
