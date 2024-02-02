using Component;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MovementComponent))]
    [RequireComponent(typeof(AttackComponent))]
    [RequireComponent(typeof(PlayerAnimationController))]
    public class PlayerAnimator : MonoBehaviour
    {

        [SerializeField] private MovementComponent movementComponent;
        [SerializeField] private AttackComponent attackComponent;
        [SerializeField] private PlayerAnimationController playerAnimationController;

        void FixedUpdate()
        {
            HandleMovementAnimations();
        }
        void HandleMovementAnimations()
        {

            if (attackComponent.IsAttacking)
            {
                playerAnimationController.ChangeCurrentState(PlayerAnimStates.Attack);
                return;
            }
            else if (!movementComponent.CheckIfGrounded())
            {
                playerAnimationController.ChangeCurrentState(PlayerAnimStates.Jump);
            }
            else
            {
                float currentSpeed = movementComponent.CurrentSpeed;
                if (currentSpeed != 0)
                {
                    playerAnimationController.ChangeCurrentState(PlayerAnimStates.Run);
                }
                else if (currentSpeed == 0)
                {
                    playerAnimationController.ChangeCurrentState(PlayerAnimStates.Idle);
                }
            }
        }

    }

}
