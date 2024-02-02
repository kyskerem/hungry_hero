using AI;
using Component;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(AIAnimController))]
public class FierceEventSubscription : MonoBehaviour
{
    HealthComponent healthComponent;
    MovementComponent movementComponent;
    AIAnimController aIAnimController;
    void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        movementComponent = GetComponent<MovementComponent>();
        aIAnimController = GetComponent<AIAnimController>();
        healthComponent.OnDied += OnDie;
        healthComponent.OnHit += OnHit;
    }
    void OnDie()
    {
        movementComponent.ChangeCanMove();
        aIAnimController.ChangeCurrentState(AIAnimStates.Die);
        Destroy(gameObject, .15f);
    }

    void OnHit()
    {
        aIAnimController.ChangeCurrentState(AIAnimStates.Hit);
    }
}
