using System.Collections;
using TMPro;
using UnityEngine;

public class GameCountdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    public static bool gameStarted = false;

    void Start()
    {
        // Reset game state when a new game starts
        gameStarted = false;
        PauseMenu.GamePaused = false;

        // Freeze gameplay during countdown
        Time.timeScale = 0f;

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        countdownText.gameObject.SetActive(true);

        countdownText.text = "3";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "GO!";
        gameStarted = true;

        yield return new WaitForSecondsRealtime(0.5f);

        countdownText.gameObject.SetActive(false);

        // Start gameplay
        Time.timeScale = 1f;
    }
}