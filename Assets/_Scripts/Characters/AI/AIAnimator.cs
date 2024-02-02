using Component;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(MovementComponent))]
    [RequireComponent(typeof(AttackComponent))]
    [RequireComponent(typeof(AIAnimController))]
    [RequireComponent(typeof(HealthComponent))]
    public class AIAnimator : MonoBehaviour
    {

        [SerializeField] private MovementComponent movementComponent;
        [SerializeField] private AttackComponent attackComponent;
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private AIAnimController aIAnimController;

        void FixedUpdate()
        {
            if (healthComponent.IsAlive) HandleMovementAnimations();
        }
        void HandleMovementAnimations()
        {

            if (attackComponent.IsAttacking)
            {
                aIAnimController.ChangeCurrentState(AIAnimStates.Attack);
                return;
            }
            if (!movementComponent.CheckIfGrounded())
            {
                aIAnimController.ChangeCurrentState(AIAnimStates.Jump);
            }
            else
            {
                float currentSpeed = movementComponent.CurrentSpeed;
                if (currentSpeed != 0)
                {
                    aIAnimController.ChangeCurrentState(AIAnimStates.Run);
                }
                else if (currentSpeed == 0)
                {
                    aIAnimController.ChangeCurrentState(AIAnimStates.Idle);
                }
            }
        }

    }

}
