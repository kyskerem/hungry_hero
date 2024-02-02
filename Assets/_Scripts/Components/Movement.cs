using UnityEditor;
using UnityEngine;

namespace Component
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 10f;
        // for sprite flipper class to use as a reference
        public Vector2 Direction { get; private set; } = Vector2.right;
        public float CurrentSpeed { get; private set; } = 0;
        [SerializeField] private float castWidth = 1f;         // Adjust the width of the box cast
        [SerializeField] private Vector2 rayDistance = new(0, .9f);         // Adjust the distance of the box cast
        [SerializeField] private float castHeight = 0.1f;      // Adjust the height of the box cast
        [SerializeField] private LayerMask groundLayer = 6;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float jumpForce = 1f;

        void Update()
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
            // Cast a box downwards from the player's position
            RaycastHit2D hit = Physics2D.BoxCast(
                transform.position + (Vector3)rayDistance,
                new Vector2(castWidth, castHeight),
                0f,
                Vector2.down,
                0f,
                groundLayer);

            if (hit.collider == null) return false;
            // Logger.Log($"Colliding with {hit.collider.tag}");
            float surfaceAngle = Vector2.Angle(hit.normal, Vector2.up);
            // Logger.Log($"surface angle is {surfaceAngle}");
            return surfaceAngle <= 90f;

        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position + (Vector3)rayDistance, new(castWidth, castHeight));
        }
    }

}
