using TMPro;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;

    private void Start()
    {
        finalScoreText.text = "Final Score: " + GameManager.finalScore;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FadeManager.Instance.ChangeScene(0);
        }
    }
}
