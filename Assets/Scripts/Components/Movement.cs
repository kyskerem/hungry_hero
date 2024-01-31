using UnityEngine;

namespace Component
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour
    {
        // ray line length for check if grounded method
        [SerializeField] private float rayLength = 1f;
        [SerializeField] private float maxSpeed = 10f;
        public float CurrentSpeed { get; private set; } = 0;
        [SerializeField] private LayerMask groundlayer = 6;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float jumpForce = 1f;
        public bool IsGrounded { get; private set; }


        void Awake()
        {
            IsGrounded = CheckIfGrounded();
        }
        public void Move(Vector2 to)
        {
            // Calculate target velocity based on the desired position (to) and speed
            Vector2 targetVelocity = new(to.x * maxSpeed, rb.velocity.y);
            rb.velocity = targetVelocity;
            // Ensure the speed doesn't exceed the maximum speed
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);

            CurrentSpeed = rb.velocity.magnitude;
            Logger.Log($"Velocity: {rb.velocity}");
        }
        public void Stop()
        {
            CurrentSpeed = 0;
        }
        public void StartJump()
        {
            if (!CheckIfGrounded()) return;
            rb.velocity = new(rb.velocity.x, jumpForce);
            IsGrounded = true;
        }


        bool CheckIfGrounded()
        {
            // Check if there is any hit for ground layer            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundlayer);
            if (hit.collider == null) return false;
            Logger.Log("grounded");
            IsGrounded = false;
            return true;
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, Vector2.down * rayLength);
        }

    }

}