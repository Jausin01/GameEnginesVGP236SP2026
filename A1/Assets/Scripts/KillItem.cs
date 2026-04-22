using UnityEngine;

public class KillItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            // Make sure its the game object and not the script!
            Destroy(collision.gameObject);
        }
    }
}
