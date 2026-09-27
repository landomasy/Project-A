using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float timeRemaining = 60f;
    public bool gameActive = true;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

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
    }
}