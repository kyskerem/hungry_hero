using System;
using System.Collections;
using UnityEngine;

namespace Component
{
    [RequireComponent(typeof(Collider2D))]
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private float damage = 10f;
        [SerializeField] private float attackTime = 1f;
        [SerializeField] private float attackCooldown = 2f;
        public event Action<float> OnAttacked;
        bool isCoolDown = false;
        public bool IsAttacking { get; private set; }

        public void Attack()
        {
            if (IsAttacking || isCoolDown) return;
            IsAttacking = true;
            StartCoroutine(nameof(HandleAttack));
        }

        IEnumerator HandleAttack()
        {
            yield return new WaitForSeconds(attackTime);
            IsAttacking = false;
            isCoolDown = true;
            yield return new WaitForSecondsRealtime(attackCooldown);
            isCoolDown = false;
        }

        public void Hit(HealthComponent healthComponent)
        {
            healthComponent.TakeDamage(damage);
            OnAttack();
        }

        void OnAttack()
        {
            OnAttacked?.Invoke(damage);
        }
    }
}
