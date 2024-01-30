using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private int initialSpeed = 150;
    [SerializeField] private int maxSpeed = 200;
    private float currentSpeed;
    [SerializeField] private float accelerationTime = .4f;
    [SerializeField] AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        if (curve == null) curve = AnimationCurve.Linear(0, initialSpeed, accelerationTime, maxSpeed);
        currentSpeed = initialSpeed;
    }

    public void Move(Vector2 to)
    {
        Logger.Log("i am moving - component");

        float acceleration = curve.Evaluate(currentSpeed / maxSpeed);
        Logger.Log($"current speed is: {currentSpeed}");
        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration);
        Vector2 movement = to * currentSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
