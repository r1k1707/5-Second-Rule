using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    [SerializeField] string sceneName;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);

        PauseMenu.GamePaused = true;
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        PauseMenu.GamePaused = false;

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}