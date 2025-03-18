using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _sensitivity = 100f;
    [SerializeField] private float _jumpForce = 5f;

    [Header("References")]
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private IMovement _movement;
    private IJump _jump;
    private ILook _look;
    private PlayerInputHandler _inputHandler;
    private GroundCheck _groundCheckComponent;

    private void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) Debug.LogError("Rigidbody component is missing on the GameObject.");

        _inputHandler = GetComponent<PlayerInputHandler>();
        if (_inputHandler == null) Debug.LogError("PlayerInputHandler component is missing on the GameObject.");

        if (_cameraTransform == null) Debug.LogError("Camera Transform is not assigned in the inspector.");
        if (_groundCheck == null) Debug.LogError("GroundCheck Transform is not assigned in the inspector.");

        _movement = new MovementComponent(rb, _speed, _cameraTransform);
        _jump = new JumpComponent(rb, _jumpForce, _groundCheck, _groundLayer);
        _look = new LookComponent(_cameraTransform, _sensitivity);

        _groundCheckComponent = _groundCheck.GetComponent<GroundCheck>();
        if (_groundCheckComponent == null)
        {
            _groundCheckComponent = _groundCheck.gameObject.AddComponent<GroundCheck>();
        }
        _groundCheckComponent.Initialize(_jump);
    }

    private void Update()
    {
        if (_jump == null || _inputHandler == null) return;

        if (_inputHandler.JumpTriggered)
        {
            _jump.HandleJump();
            _inputHandler.ResetJump();
        }

        _jump.Update();
    }

    private void FixedUpdate()
    {
        if (_movement == null || _inputHandler == null) return;
        _movement.HandleMovement(_inputHandler.MoveInput);
    }

    private void LateUpdate()
    {
        if (_look == null || _inputHandler == null) return;
        _look.HandleLook(_inputHandler.LookInput);
    }
}