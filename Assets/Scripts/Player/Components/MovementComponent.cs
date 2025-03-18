using UnityEngine;

public class MovementComponent : IMovement
{
    private readonly Rigidbody _rb;
    private readonly float _speed;
    private readonly Transform _cameraTransform;

    public MovementComponent(Rigidbody rb, float speed, Transform cameraTransform)
    {
        _rb = rb;
        _speed = speed;
        _cameraTransform = cameraTransform;
    }

    public void HandleMovement(Vector2 input)
    {
        float cameraYRotation = _cameraTransform.eulerAngles.y;

        Vector3 moveDirection = Quaternion.Euler(0, cameraYRotation, 0) * new Vector3(input.x, 0, input.y);
        moveDirection.Normalize();

        _rb.linearVelocity = new Vector3(moveDirection.x * _speed, _rb.linearVelocity.y, moveDirection.z * _speed);
    }
}