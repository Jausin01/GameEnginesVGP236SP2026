using UnityEngine;

public class TearCollision : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip hitSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }
}
