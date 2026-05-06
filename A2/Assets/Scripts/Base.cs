using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    public bool HasPlayer()
    {
        Collider2D hit = Physics2D.OverlapBox(
            transform.position,
            transform.localScale,
            0f,
            playerLayer
        );

        return hit != null;
    }
}
