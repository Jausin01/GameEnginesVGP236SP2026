using UnityEngine;

public class ScoreAdding : MonoBehaviour
{
    [SerializeField] private int _score = 10;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip lowGold;
    [SerializeField] private AudioClip highGold;
    [SerializeField] private AudioClip HolyGold;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TearDrop"))
        {
            Debug.Log("Won " + _score + " points");
            if (_score < 50)
            {
                sfxSource.PlayOneShot(lowGold);
            }
            else if (_score >= 50 && _score < 100)
            {
                sfxSource.PlayOneShot(highGold);
            }
            else
            {
                sfxSource.PlayOneShot(HolyGold);
            }
                gameManager.AddScore(_score);
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Something that wasn't supposed to collide... Collided.");
        }

    }
}
