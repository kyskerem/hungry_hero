using UnityEngine;

namespace Component
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour
    {
        // ray line length for check if grounded method
        [SerializeField] private float rayLength = .95f;
        [SerializeField] private float maxSpeed = 10f;
        // for sprite flipper class to use as a reference
        public Vector2 Direction { get; private set; }
        public float CurrentSpeed { get; private set; } = 0;
        [SerializeField] private LayerMask groundlayer = 6;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float jumpForce = 1f;

        void Awake()
        {
            CheckIfGrounded();
        }
        void FixedUpdate()
        {
            CheckIfGrounded();
        }
        public void Move(Vector2 to)
        {
            Direction = to;
            // Calculate target velocity based on the desired position (to) and speed
            Vector2 targetVelocity = new(to.x * maxSpeed, rb.velocity.y);
            rb.velocity = targetVelocity;
            // Ensure the speed doesn't exceed the maximum speed
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
            CurrentSpeed = rb.velocity.magnitude;
        }
        public void Stop()
        {
            CurrentSpeed = 0;
        }
        public void StartJump()
        {
            if (!CheckIfGrounded()) return;
            rb.velocity = new(rb.velocity.x, jumpForce);
        }


        public bool CheckIfGrounded()
        {
            // Check if there is any hit for ground layer            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundlayer);
            return hit.collider != null;
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, Vector2.down * rayLength);
        }

    }

}