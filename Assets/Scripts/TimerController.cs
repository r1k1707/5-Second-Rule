using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float elapsedTime = 0f;

    void Start()
    {
        elapsedTime = 0f;

        UpdateTimerText();
    }

    void Update()
    {
        // Don't want it to start until countdown is finished >:(
        if (!GameCountdown.gameStarted)
            return;

        // Stop when paused, won, or game over
        if (PauseMenu.GamePaused || VictoryMenu.GameWon)
            return;

        elapsedTime += Time.deltaTime;

        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ShowFinalTime(TMP_Text text)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        text.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}