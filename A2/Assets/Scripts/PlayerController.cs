using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class PlayerStats
{
    public float moveSpeed = 5.0f;
    public float jumpSpeed = 3.0f;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [Header("Systems")]
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private Animator _animator;

    [Header("Stats")]
    [SerializeField] private PlayerStats _playerStats = new PlayerStats();

    [Header("Input (ASSIGNED PER CHARACTER)")]
    [SerializeField] private InputActionAsset _inputActions;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    public float VerticalInput { get; private set; }
    private float _desiredHorizontalSpeed;
    private float _facingDirection;
    private bool _isFalling;
    private bool _isJumping;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.freezeRotation = true;

        
        var map = _inputActions.FindActionMap("Player");

        _moveAction = map.FindAction("Move");
        _jumpAction = map.FindAction("Jump");

        _jumpAction.performed += OnJump;
    }

    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.performed -= OnJump;

        _moveAction.Disable();
        _jumpAction.Disable();
    }

    private void Update()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();

        _desiredHorizontalSpeed = input.x * _playerStats.moveSpeed;
        VerticalInput = input.y;

        if (_rigidBody.linearVelocityY < -0.1f)
        {
            _isFalling = true;
            _isJumping = false;
        }
        else if (_isFalling && _groundCheck.IsGrounded && _rigidBody.linearVelocityY < 0.1f)
        {
            _isFalling = false;
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocityX = _desiredHorizontalSpeed;

        if (MathF.Abs(_desiredHorizontalSpeed) > 0.1f)
        {
            _facingDirection = _desiredHorizontalSpeed > 0.0f ? 0.0f : 1.0f;
        }

        _animator.SetFloat("Speed", MathF.Abs(_desiredHorizontalSpeed));
        _animator.SetFloat("Direction", _facingDirection);
        _animator.SetBool("Jump", _isJumping);
        _animator.SetBool("Fall", _isFalling);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_groundCheck.IsGrounded && _rigidBody.linearVelocityY < 0.1f)
        {
            _rigidBody.linearVelocityY = _playerStats.jumpSpeed;
            _isJumping = true;
        }
    }
}