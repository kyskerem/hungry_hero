using Component;
using UnityEngine;

[RequireComponent(typeof(AIPlatformChecker))]
[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(MovementComponent))]
public class AIMovementController : MonoBehaviour
{
    [SerializeField] private AIPlatformChecker platformChecker;
    [SerializeField] private MovementComponent movementComponent;
    [SerializeField] private HealthComponent healthComponent;
    private Vector2 direction;
    void Awake()
    {
        platformChecker = GetComponent<AIPlatformChecker>();
        movementComponent = GetComponent<MovementComponent>();
        healthComponent = GetComponent<HealthComponent>();
        direction = movementComponent.Direction;
    }
    void FixedUpdate()
    {
        if (!healthComponent.IsAlive) return;
        bool isNextStepPlatform = platformChecker.CheckIfPlatform();
        if (!isNextStepPlatform)
        {
            platformChecker.Mirror = !platformChecker.Mirror;
            direction = -movementComponent.Direction;
        }
        movementComponent.Move(direction);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            Logger.Log("Collide With Enemy");
            platformChecker.Mirror = !platformChecker.Mirror;
            direction = -direction;
            movementComponent.Move(direction);
        };
    }
}
