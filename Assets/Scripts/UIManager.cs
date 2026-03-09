using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Paneller")]
    public GameObject mainMenuPanel;
    public GameObject gameHUDPanel;
    public GameObject gameOverPanel;

    [Header("UI Elemanları")]
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverTitleText; 
    public TextMeshProUGUI gameOverScoreText;

    [Header("Referanslar")]
    public Transform playerHole;
    
    private float timeRemaining = 120f;
    private bool isGameActive = false;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        gameHUDPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        Time.timeScale = 0; 
    }

    public void StartGame()
    {
        isGameActive = true;
        mainMenuPanel.SetActive(false);
        gameHUDPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        
        Time.timeScale = 1;
    }

    void Update()
    {
        if (!isGameActive) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeUI();
        }
        else
        {
            timeRemaining = 0;
            GameOver("TIME OVER"); 
        }

        scoreText.text = "SIZE: " + playerHole.localScale.x.ToString("F1") + "m";
    }

    private void UpdateTimeUI()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GameOver(string message = "GAME OVER")
    {
        if (!isGameActive) return; 

        isGameActive = false;
        Time.timeScale = 0;

        gameHUDPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        if(gameOverTitleText != null)
            gameOverTitleText.text = message;

        float currentSize = playerHole.localScale.x;
        gameOverScoreText.text = "Final size: " + currentSize.ToString("F1") + "m";

        if (currentSize > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", currentSize);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        RestartGame(); 
    }
}