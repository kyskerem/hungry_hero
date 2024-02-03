using System;
using UnityEngine;

namespace Component
{

    public class HungerComponent : MonoBehaviour
    {
        private float maxHunger = 100;
        private float currentHunger = 0;
        public event Action OnFull;
        public event Action<float, float> OnHungerChanged;
        void Awake()
        {
            // Ensure hunger bar is correct
            OnHungerChanged?.Invoke(currentHunger, maxHunger);
        }
        public void IncreaseHunger(int number)
        {
            currentHunger += number;
            OnHungerChanged?.Invoke(currentHunger, maxHunger);
            if (currentHunger >= maxHunger)
            {
                OnFull?.Invoke();
            }
        }
    }

}