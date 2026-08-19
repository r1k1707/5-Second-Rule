using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;
    public string sceneName;

    private void Start()
    {
        // Gameplay starts with cursor hidden
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Don't allow pausing during countdown
        if (!GameCountdown.gameStarted)
            return;

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (GamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;
        GamePaused = true;

        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1f;
        GamePaused = false;

        Cursor.visible = false;
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