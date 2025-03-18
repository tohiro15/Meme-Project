using UnityEngine;

public class JumpComponent : IJump
{
    private readonly Rigidbody _rb;
    private readonly float _jumpForce;
    private readonly Transform _groundCheck;
    private readonly LayerMask _groundLayer;

    private bool _isGrounded;
    private bool _jumpRequested;

    public JumpComponent(Rigidbody rb, float jumpForce, Transform groundCheck, LayerMask groundLayer)
    {
        _rb = rb;
        _jumpForce = jumpForce;
        _groundCheck = groundCheck;
        _groundLayer = groundLayer;
    }

    public void Update()
    {
        Debug.Log("JumpComponent Update called. Grounded: " + _isGrounded + ", Jump Requested: " + _jumpRequested);

        if (_isGrounded && _jumpRequested)
        {
            Debug.Log("Jump executed");
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _jumpRequested = false;
        }
    }

    public void SetGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }

    public void HandleJump()
    {
        Debug.Log("Jump requested");
        _jumpRequested = true;
    }
}