using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private LayerMask _ignoreLayers;

    private int _numCollisions = 0;

    public bool IsGrounded => _numCollisions > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;

        if (IsIgnored(layer)) return;

        if (IsGround(layer))
            _numCollisions++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;

        if (IsIgnored(layer)) return;

        if (IsGround(layer))
            _numCollisions--;
    }

    private bool IsGround(int layer)
    {
        return (_groundLayers.value & (1 << layer)) != 0;
    }

    private bool IsIgnored(int layer)
    {
        return (_ignoreLayers.value & (1 << layer)) != 0;
    }
}
