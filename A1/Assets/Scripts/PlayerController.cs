 using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float leftLimit = -7f;
    [SerializeField] private float rightLimit = 7f;

    [SerializeField] private GameObject tearPrefab;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float tearHorizontalSpeed = 2f;

    private int direction = 1;

    [SerializeField] private int maxTears = 3;
    private int currentTears = 0;

    private void Move()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        if (transform.position.x >= rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x <= leftLimit)
        {
            direction = 1;
        }
    }
    public void OnTearDestroyed()
    {
        currentTears--;
    }
    private void Update()
    {
        if (gameManager.isGameOver)
            return;

        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentTears >= maxTears)
                return;

            GameObject tear = Instantiate(tearPrefab, transform.position, Quaternion.identity);

            currentTears++;

            Rigidbody2D rb = tear.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(direction * tearHorizontalSpeed, 0f);

            TearLife tearLife = tear.GetComponent<TearLife>();
            tearLife.Init(this);

            if (audioSource != null && shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
    }
}
