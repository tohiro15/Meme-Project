using UnityEngine;

public class LookComponent : ILook
{
    private readonly Transform _cameraTransform;
    private readonly float _sensitivity;

    private float _verticalRotation = 0f;

    public LookComponent(Transform cameraTransform, float sensitivity)
    {
        _cameraTransform = cameraTransform;
        _sensitivity = sensitivity;
    }

    public void HandleLook(Vector2 input)
    {
        float mouseX = input.x * _sensitivity * Time.deltaTime;
        float mouseY = input.y * _sensitivity * Time.deltaTime;

        _verticalRotation -= mouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90f, 90f);

        _cameraTransform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        _cameraTransform.parent.Rotate(Vector3.up * mouseX);
    }
}