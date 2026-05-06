using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LadderClimb : MonoBehaviour
{
    private bool _isInLadder = false;
    private bool _isClimbing = false;

    [SerializeField] private PlayerController _player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float _climbSpeed = 5f;
    List<Collider2D> colliders = new List<Collider2D>();


    private void Update()
    {
        _isClimbing = _isInLadder && Mathf.Abs(_player.VerticalInput) > 0.1f;
    }

    private void FixedUpdate()
    {
        if (_isClimbing)
        {
            rb.gravityScale = 0f;

            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                _player.VerticalInput * _climbSpeed
            );
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isInLadder = true;
            colliders.Add(other);
            Debug.Log("Entrou na escada");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            colliders.Remove(other);

            if (colliders.Count == 0)
            {
                _isInLadder = false;
                _isClimbing = false;
            }
            
        }
    }
}
