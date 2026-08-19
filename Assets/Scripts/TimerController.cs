using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TMP_Text finalTimeText;

    private float elapsedTime = 0f;
    private bool timerRunning = false;

    void Start()
    {
        elapsedTime = 0f;
        timerRunning = false;

        UpdateTimerText();
    }

    void Update()
    {
        // Don't start counting until the countdown is finished
        if (!GameCountdown.gameStarted)
            return;

        // Stop timer when game is paused or won
        if (PauseMenu.GamePaused || VictoryMenu.GameWon)
            return;

        timerRunning = true;

        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
        }

        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ShowFinalTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        finalTimeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}