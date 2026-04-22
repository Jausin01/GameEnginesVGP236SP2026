using UnityEngine;

public class BonusCollect : MonoBehaviour
{
    [SerializeField] private int bonusPoints = 50;

    [SerializeField] private AudioClip normalSound;
    [SerializeField] private AudioClip rareSound;
    [SerializeField, Range(0f, 1f)] private float rareChance = 0.1f;

    private GameManager gameManager;
    private BonusSpawner treasureManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        treasureManager = FindAnyObjectByType<BonusSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("TearDrop")) return;

        Debug.Log("IT PLAYED!");
        PlaySound();

        gameManager.AddScore(bonusPoints);

        treasureManager.SpawnBonus();

        Destroy(gameObject);
    }

    private void PlaySound()
    {
        float roll = Random.value;

        if (roll < rareChance && rareSound != null)
        {
            AudioSource.PlayClipAtPoint(rareSound, transform.position);
            Debug.Log("RARE SONG UHU!");
        }
        else if (normalSound != null)
        {
            AudioSource.PlayClipAtPoint(normalSound, transform.position);
            Debug.Log("Nothing to see here :)");
        }
    }
}