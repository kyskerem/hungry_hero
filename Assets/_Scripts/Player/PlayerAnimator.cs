using Component;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MovementComponent))]
    [RequireComponent(typeof(PlayerAnimationController))]
    public class PlayerAnimator : MonoBehaviour
    {

        [SerializeField] private MovementComponent movementComponent;
        [SerializeField] private PlayerAnimationController playerAnimationController;

        void FixedUpdate()
        {
            HandleMovementAnimations();
        }
        void HandleMovementAnimations()
        {
            float currentSpeed = movementComponent.CurrentSpeed;

            bool IsGrounded = movementComponent.CheckIfGrounded();
            if (!IsGrounded)
            {
                playerAnimationController.ChangeCurrentState(PlayerAnimStates.Jump);
            }
            else
            {
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
