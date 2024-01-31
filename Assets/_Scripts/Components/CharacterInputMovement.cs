using Component;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class CharacterInputMovement : MonoBehaviour
{
    MovementComponent movementComponent;
    private Vector2 direction = Vector2.zero;
    void Awake()
    {
        movementComponent = GetComponent<MovementComponent>();
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
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
