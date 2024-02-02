using Component;
using UnityEngine;
namespace Player
{
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(MovementComponent))]
    public class PlayerEventSubscription : MonoBehaviour
    {
        HealthComponent healthComponent;
        MovementComponent movementComponent;
        PlayerAnimationController playerAnimationController;
        void Awake()
        {
            healthComponent = GetComponent<HealthComponent>();
            playerAnimationController = GetComponent<PlayerAnimationController>();
            movementComponent = GetComponent<MovementComponent>();
            healthComponent.OnDied += OnDie;
            healthComponent.OnHit += OnHit;
        }
        void OnDie()
        {
            Logger.LogWarning("Player is dead");
            movementComponent.ChangeCanMove();
            playerAnimationController.ChangeCurrentState(PlayerAnimStates.Die);
            // Time.timeScale = 0; // Freeze the game
        }
        void OnHit()
        {
            playerAnimationController.ChangeCurrentState(PlayerAnimStates.Damage);
        }
    }

}