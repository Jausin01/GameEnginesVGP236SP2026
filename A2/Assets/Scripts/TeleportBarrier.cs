using UnityEngine;

public class TeleportBarrier : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.transform.position = _targetPosition.position;
        }
    }
}
