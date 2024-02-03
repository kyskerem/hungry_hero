using Component;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(AttackComponent))]

public class CharacterInputMovement : MonoBehaviour
{
    MovementComponent movementComponent;
    HealthComponent healthComponent;
    AttackComponent attackComponent;
    private Vector2 direction = Vector2.zero;
    void Awake()
    {
        movementComponent = GetComponent<MovementComponent>();
        attackComponent = GetComponent<AttackComponent>();
        healthComponent = GetComponent<HealthComponent>();
    }
    void Update()
    {
        if (healthComponent.IsAlive) Movement();
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space)) attackComponent.Attack();
        if (Input.GetKeyDown(KeyCode.UpArrow)) movementComponent.StartJump();
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
