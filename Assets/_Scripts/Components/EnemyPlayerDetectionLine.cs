using Component;
using UnityEngine;
[RequireComponent(typeof(MovementComponent))]
[RequireComponent((typeof(AttackComponent)))]
public class EnemyPlayerDetectionLine : MonoBehaviour
{
    // Must be equal to attack area colliders length
    [SerializeField] private float rayDistance = .2f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private MovementComponent movementComponent;
    [SerializeField] private AttackComponent attackComponent;


    void Awake()
    {
        movementComponent = GetComponent<MovementComponent>();
        attackComponent = GetComponent<AttackComponent>();
    }
    void Update()
    {
        Detect();
    }
    void Detect()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movementComponent.Direction, rayDistance, playerLayer);
        if (hit.collider == null) return;
        hit.collider.gameObject.TryGetComponent(out HealthComponent healthComponent);
        movementComponent.Stop();
        attackComponent.Attack();
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(movementComponent.Direction.x * rayDistance, 0, 0));
    }
}
