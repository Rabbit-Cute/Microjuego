using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI scoreText;
    public static bool isGameOver = false; 
    public TextMeshProUGUI stopRestartText;

    public void ShowGameOver()
    {   
        isGameOver = true;
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;

        if (scoreText != null) scoreText.gameObject.SetActive(false);
        if (stopRestartText != null) stopRestartText.gameObject.SetActive(false);
    }

    public void Restart()
    {   
        if (scoreText != null) scoreText.gameObject.SetActive(true);
        if (stopRestartText != null) stopRestartText.gameObject.SetActive(true);
        isGameOver = false;
        Time.timeScale = 1f;
        Player.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}