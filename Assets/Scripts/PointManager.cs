using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;

    public static int highscore;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text highScoreText;

    void Start()
    {
        score = 0;

        UpdateScoreText();
    }

    public void UpdateScore(int points)
    {
        score += points;

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void ShowFinalScore(TMP_Text finalScoreText, TMP_Text highScoreText)
    {
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);

        if (score > savedHighScore)
        {
            savedHighScore = score;

            PlayerPrefs.SetInt("SavedHighScore", savedHighScore);
            PlayerPrefs.Save();
        }

        finalScoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + savedHighScore;
    }
}