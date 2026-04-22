using UnityEngine;

public class DamageZones : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TearDrop"))
        {
            gameManager.LoseLife(damage);
            Destroy(collision.gameObject);
        }
    }
}
