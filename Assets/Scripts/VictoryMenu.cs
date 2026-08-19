using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public static bool GameWon = false;

    [SerializeField] private GameObject victoryUI;
    [SerializeField] private int enemiesToDefeat = 100;
    [SerializeField] private string sceneName;
    private PointManager pointManager;
    private TimerController timerController;

    private int enemiesDefeated = 0;

    private void Start()
    {
        victoryUI.SetActive(false);
        GameWon = false;
        Cursor.visible = false;
        pointManager = FindFirstObjectByType<PointManager>();
        timerController = FindFirstObjectByType<TimerController>();
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;

        Debug.Log("Enemies defeated: " + enemiesDefeated + "/" + enemiesToDefeat);

        if (enemiesDefeated >= enemiesToDefeat)
        {
            Victory();
        }
    }

    private void Victory()
    {
        GameWon = true;
        victoryUI.SetActive(true);
        PauseMenu.GamePaused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;

        if (pointManager != null)
        {
            pointManager.HighScoreUpdate();
        }
        if (timerController != null)
        {
            timerController.ShowFinalTime();
        }
        Debug.Log("YOU WON?!");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        PauseMenu.GamePaused = false;
        GameWon = false;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMain()
    {
        Time.timeScale = 1f;
        PauseMenu.GamePaused = false;
        GameWon = false;
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
