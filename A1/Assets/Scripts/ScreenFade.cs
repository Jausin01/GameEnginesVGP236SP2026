using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    private Image fadeImage;
    private Canvas canvas;

    [SerializeField] private float fadeSpeed = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CreateFadeUI();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void CreateFadeUI()
    {
        GameObject canvasObj = new GameObject("FadeCanvas");
        canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;

        DontDestroyOnLoad(canvasObj);

        GameObject imageObj = new GameObject("FadeImage");
        imageObj.transform.SetParent(canvasObj.transform, false);

        fadeImage = imageObj.AddComponent<Image>();

        RectTransform rt = fadeImage.rectTransform;
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        fadeImage.color = new Color(0, 0, 0, 1);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    public void ChangeScene(int sceneIndex)
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut(sceneIndex));
    }

    private IEnumerator FadeIn()
    {
        if (fadeImage == null) yield break;

        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, t);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
    }

    private IEnumerator FadeOut(int sceneIndex)
    {
        if (fadeImage == null) yield break;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, t);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1);

        SceneManager.LoadScene(sceneIndex);
    }
}