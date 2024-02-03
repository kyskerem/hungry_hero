using System;
using UnityEngine;

namespace Component
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 30f;
        public event Action<float, float> OnHealthChanged;
        public event Action OnDied;
        public event Action OnHit;
        private float health;
        public bool IsAlive { get; private set; } = true;
        void Awake()
        {
            health = maxHealth;
            // to ensure every health bar is correct
            OnHealthChange();
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            OnHealthChange();
            if (health <= 0)
            {
                IsAlive = false;
                OnDie();
                return;
            };
            Hit();
        }
        public void Heal(int number)
        {
            health += number;
            health = Mathf.Clamp(health, 0, maxHealth);
            OnHealthChange();
        }
        void OnDie()
        {
            OnDied?.Invoke();
        }
        void Hit()
        {
            OnHit?.Invoke();
        }
        void OnHealthChange()
        {
            OnHealthChanged?.Invoke(health, maxHealth);
        }
    }
}
