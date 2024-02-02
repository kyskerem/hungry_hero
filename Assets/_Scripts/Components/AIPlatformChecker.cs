using System.Collections;
using Component;
using Unity.VisualScripting;
using UnityEngine;

public class AIPlatformChecker : MonoBehaviour
{
    [SerializeField] private float castWidth;
    [SerializeField] private float castHeight;
    [SerializeField] private Vector2 rayDistance;
    public bool Mirror { get; set; } = false;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        CheckIfPlatform();
    }
    public bool CheckIfPlatform()
    {
        rayDistance.x = Mathf.Abs(rayDistance.x) * (Mirror ? -1 : 1);
        // Cast a box downwards from the ai's position
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position + (Vector3)rayDistance,
            new Vector2(castWidth, castHeight),
            0f,
            Vector2.down,
            0f,
            groundLayer);

        return hit.collider != null;

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position + (Vector3)rayDistance, new(castWidth, castHeight));
    }

}
