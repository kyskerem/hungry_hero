using UnityEngine;

namespace Component
{
    [RequireComponent(typeof(MovementComponent))]
    public class SpriteFlipper : MonoBehaviour
    {

        private MovementComponent movementComponent;
        [SerializeField] private bool isFacingRight;
        private bool flip = false;
        void Awake()
        {
            movementComponent = GetComponent<MovementComponent>();
            Vector3 scale = gameObject.transform.localScale;
            if (isFacingRight)
            {
                scale.x = Mathf.Abs(scale.x) * -1;
            }
            gameObject.transform.localScale = scale;
        }

        void FixedUpdate()
        {
            Vector3 scale = gameObject.transform.localScale;

            if (movementComponent.CurrentSpeed != 0)
            {
                bool newFlip;
                if (isFacingRight)
                {
                    newFlip = movementComponent.Direction.x > 0;
                }
                else
                {
                    newFlip = movementComponent.Direction.x < 0;

                }

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