using UnityEngine;

public class ExtraLifeZone : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip lifeSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TearDrop"))
        {
            if (audioSource != null && lifeSound != null)
            {
                audioSource.PlayOneShot(lifeSound);
            }

            gameManager.AddLife(1);
            Destroy(collision.gameObject);
        }
    }
}
