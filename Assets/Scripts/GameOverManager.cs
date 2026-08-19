using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    [SerializeField] string sceneName;

    void Start()
    {
        gameOverUI.SetActive(false);
        Cursor.visible = false;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        PauseMenu.GamePaused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        PauseMenu.GamePaused = false;
        Cursor.visible = false;
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