using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected PlayerInput _pInput;
    protected Vector2 _moveInput;
    protected Vector2 _lookInput;

    protected virtual void Awake()
    {
        _pInput = new PlayerInput();
    }

    protected virtual void OnEnable()
    {
        _pInput.Enable();
        _pInput.Player.Movement.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _pInput.Player.Movement.canceled += ctx => _moveInput = Vector2.zero;
        _pInput.Player.Look.performed += ctx => _lookInput = ctx.ReadValue<Vector2>();
        _pInput.Player.Look.canceled += ctx => _lookInput = Vector2.zero;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void OnDisable()
    {
        _pInput.Disable();
        _pInput.Player.Movement.performed -= ctx => _moveInput = ctx.ReadValue<Vector2>();
        _pInput.Player.Movement.canceled -= ctx => _moveInput = Vector2.zero;
        _pInput.Player.Look.performed -= ctx => _lookInput = ctx.ReadValue<Vector2>();
        _pInput.Player.Look.canceled -= ctx => _lookInput = Vector2.zero;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}