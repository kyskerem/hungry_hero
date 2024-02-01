using Component;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(AttackComponent))]

public class CharacterInputMovement : MonoBehaviour
{
    MovementComponent movementComponent;
    AttackComponent attackComponent;
    private Vector2 direction = Vector2.zero;
    void Awake()
    {
        movementComponent = GetComponent<MovementComponent>();
        attackComponent = GetComponent<AttackComponent>();
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) attackComponent.Attack();
        if (Input.GetKeyDown(KeyCode.Space)) movementComponent.StartJump();
        direction.x = Input.GetAxis("Horizontal");
        if (direction.x != 0)
        {
            movementComponent.Move(direction);
        }
        else
        {
            movementComponent.Stop();
        };

    }

}
