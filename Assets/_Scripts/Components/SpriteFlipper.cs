using UnityEngine;

namespace Component
{
    [RequireComponent(typeof(MovementComponent))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteFlipper : MonoBehaviour
    {
        private SpriteRenderer renderer;
        private MovementComponent movementComponent;
        private bool flipX = true;
        void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
            movementComponent = GetComponent<MovementComponent>();
        }

        void FixedUpdate()
        {
            if (movementComponent.CurrentSpeed != 0)
            {
                flipX = movementComponent.Direction.x < 0;
                renderer.flipX = flipX;
            }
            else
            {
                renderer.flipX = flipX;
            }
        }
    }
}