using Component;
using UnityEngine.SceneManagement;
using UnityEngine;
namespace Player
{
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(MovementComponent))]
    [RequireComponent(typeof(HungerComponent))]
    public class PlayerEventSubscription : MonoBehaviour
    {
        HealthComponent healthComponent;
        MovementComponent movementComponent;
        HungerComponent hungerComponent;
        PlayerAnimationController playerAnimationController;
        void Awake()
        {
            hungerComponent = GetComponent<HungerComponent>();
            healthComponent = GetComponent<HealthComponent>();
            playerAnimationController = GetComponent<PlayerAnimationController>();
            movementComponent = GetComponent<MovementComponent>();
            healthComponent.OnDied += OnDie;
            healthComponent.OnHit += OnHit;
            hungerComponent.OnFull += OnFull;
        }
        void OnDie()
        {
            Logger.LogWarning("Player is dead");
            movementComponent.ChangeCanMove();
            playerAnimationController.ChangeCurrentState(PlayerAnimStates.Die);
            Loader.Instance.RestartLevel();
        }
        void OnHit()
        {
            playerAnimationController.ChangeCurrentState(PlayerAnimStates.Damage);
        }
        void OnFull()
        {
            Loader.Instance.LoadNextLevel();
        }

    }

}