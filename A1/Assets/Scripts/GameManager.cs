using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] int lives = 3;
    [SerializeField] private GameObject[] hearts;

    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip twoLivesSound;
    [SerializeField] private AudioClip oneLifeSound;
    [SerializeField] private AudioClip zeroLivesSound;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameObject gameOverText;
    public bool isGameOver = false;
    public static int finalScore;
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < lives);
        }
    }

    public void LoseLife(int amount)
    {
        lives -= amount;

        if (lives < 0)
            lives = 0;

        UpdateHearts();

        sfxSource.PlayOneShot(hurtSound);

        if (lives == 2)
            sfxSource.PlayOneShot(twoLivesSound);
        else if (lives == 1)
            sfxSource.PlayOneShot(oneLifeSound);
        else if (lives == 0)
            sfxSource.PlayOneShot(zeroLivesSound);

        if (lives <= 0)
        {
            sfxSource.PlayOneShot(deathSound);
            GameOver();
        }
    }

    private void Update()
    {
        if (!isGameOver) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            finalScore = score;
            Time.timeScale = 1f;
            FadeManager.Instance.ChangeScene(2);
        }
    }

    public void AddLife(int amount)
    {
        lives += amount;

        if (lives > 3)
            lives = 3;

        UpdateHearts();

        
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}
