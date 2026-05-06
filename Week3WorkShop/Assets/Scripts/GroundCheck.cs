using Unity.VisualScripting;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int _numCollisions = 0;
    public bool IsGrounded { get { return _numCollisions > 0; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++_numCollisions;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        --_numCollisions;
    }
}
