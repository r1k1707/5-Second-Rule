using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private string sceneName;

    [SerializeField] private TMP_Text finalTimeText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text highScoreText;

    private PointManager pointManager;
    private TimerController timerController;

    private void Start()
    {
        gameOverUI.SetActive(false);
        Cursor.visible = false;
        pointManager = FindFirstObjectByType<PointManager>();
        timerController = FindFirstObjectByType<TimerController>();
    }

    public void GameOver()
    {
        // Get final time
        if (timerController != null)
        {
            timerController.ShowFinalTime(finalTimeText);
        }

        // Get final score and high score
        if (pointManager != null)
        {
            pointManager.ShowFinalScore(finalScoreText, highScoreText);
        }

        gameOverUI.SetActive(true);
        PauseMenu.GamePaused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Debug.Log("GAME OVER");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        PauseMenu.GamePaused = false;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMain()
    {
        Time.timeScale = 1f;
        PauseMenu.GamePaused = false;
        Cursor.visible = true;
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