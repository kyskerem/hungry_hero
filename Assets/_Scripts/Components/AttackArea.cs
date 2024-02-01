using Component;
using UnityEngine;

[RequireComponent(typeof(AttackComponent))]
[RequireComponent(typeof(Collider2D))]
public class AttackArea : MonoBehaviour
{
    private AttackComponent attackComponent;
    [SerializeField] private Collider2D attackArea;
    void Awake()
    {
        attackComponent = GetComponent<AttackComponent>();

    }
    void Update()
    {
        attackArea.gameObject.SetActive(attackComponent.IsAttacking);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        _ = other.TryGetComponent(out HealthComponent healthComponent);
        if (healthComponent == null) return;
        attackComponent.Hit(healthComponent);
    }
}
