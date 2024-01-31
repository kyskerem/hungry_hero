namespace Player
{
    using UnityEngine;

    public class PlayerFollowCamera : MonoBehaviour
    {
        public Transform cameraTransform;
        public Vector3 offset = new(0f, 2f, -5f);
        public float smoothTime = 0.3f;

        private Vector3 velocity = Vector3.zero;

        void FixedUpdate()
        {
            if (cameraTransform != null)
            {
                Vector3 targetPosition = cameraTransform.position + offset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
        }
    }
}
