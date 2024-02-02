using System.Collections;
using Component;
using UnityEngine;

[RequireComponent(typeof(AIPlatformChecker))]
[RequireComponent(typeof(MovementComponent))]
public class AIMovementController : MonoBehaviour
{
    [SerializeField] private AIPlatformChecker platformChecker;
    [SerializeField] private MovementComponent movementComponent;
    private Vector2 direction;
    void Awake()
    {
        platformChecker = GetComponent<AIPlatformChecker>();
        movementComponent = GetComponent<MovementComponent>();
        direction = movementComponent.Direction;
        StartCoroutine(nameof(HandleAIMovement));
    }
    IEnumerator HandleAIMovement()
    {
        bool isNextStepPlatform = platformChecker.CheckIfPlatform();
        if (!isNextStepPlatform)
        {
            platformChecker.Mirror = !platformChecker.Mirror;
            direction = -movementComponent.Direction;
        }
        movementComponent.Move(direction);
        yield return new WaitForSeconds(.3f);
        StartCoroutine(nameof(HandleAIMovement));
    }
}
