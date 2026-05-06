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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D _rigidBody = null;

    [SerializeField] private GroundCheck _groundCheck = null;

    [SerializeField] private PlayerStats _playerStats = new PlayerStats();
    [SerializeField] private PlayerInput _playerInput = null;
    [SerializeField] private InputAction _moveAction = null;
    [SerializeField] private InputAction _jumpAction = null;
    [SerializeField] private Animator _animator = null;
    private float _DesiredHorizontalSpeed = 0.0f;
    private float _facingDirection = 0.0f;
    private bool isFalling = false;
    private bool isJumping = false;
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move;
        _jumpAction = _playerInput.Player.Jump;
        _jumpAction.performed += OnJump;
    }

    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();

    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _DesiredHorizontalSpeed = _moveAction.ReadValue<Vector2>().x * _playerStats.moveSpeed;

        if (_rigidBody.linearVelocityY < -0.1f)
        {
            isFalling = true;
            isJumping = false; 
        }
        else if (isFalling && _groundCheck.IsGrounded && _rigidBody.linearVelocityY < 0.1f)
        {
            isFalling = false;
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocityX = _DesiredHorizontalSpeed;
        if (MathF.Abs(_DesiredHorizontalSpeed) > 0.1f)
        {
            _facingDirection = (_DesiredHorizontalSpeed) > 0.0f ? 0.0f : 1.0f;
        }
        _animator.SetFloat("Speed", MathF.Abs(_DesiredHorizontalSpeed));
        _animator.SetFloat("Direction", _facingDirection);
        _animator.SetBool("Jump", isJumping);
        _animator.SetBool("Fall", isFalling);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_groundCheck.IsGrounded && _rigidBody.linearVelocityY < 0.1f)
        {
            _rigidBody.linearVelocityY = _playerStats.jumpSpeed;
            isJumping = true;

        }
        
    }

}
