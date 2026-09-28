using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float timeRemaining = 60f;
    public bool gameActive = true;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!gameActive) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame();
        }

        UpdateHUD();
    }

    void UpdateHUD()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
    }

    public void AddScore(int amount)
    {
        if (!gameActive) return;
        score += amount;
    }

    void EndGame()
    {
        gameActive = false;
        Debug.Log("Game Over! Final Score: " + score);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + score;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // in case it was paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // must match your Main Menu scene's exact name
    }
}