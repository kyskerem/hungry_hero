using UnityEngine;

namespace Component
{
    [RequireComponent(typeof(MovementComponent))]
    public class SpriteFlipper : MonoBehaviour
    {

        private MovementComponent movementComponent;
        private bool flip = false;
        void Awake()
        {
            movementComponent = GetComponent<MovementComponent>();
        }

        void FixedUpdate()
        {
            Vector3 scale = gameObject.transform.localScale;

            if (movementComponent.CurrentSpeed != 0)
            {
                bool newFlip = movementComponent.Direction.x < 0;

                // Check if the flip state has changed
                if (newFlip != flip)
                {
                    flip = newFlip;
                    scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                }
            }

            gameObject.transform.localScale = scale;
        }

    }
}