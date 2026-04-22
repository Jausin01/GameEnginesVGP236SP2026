using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "GameScene";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FadeManager.Instance.ChangeScene(1);
        }
    }
}
