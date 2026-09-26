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

        scoreText.gameObject.SetActive(false);
        stopRestartText.gameObject.SetActive(false);
    }

    public void Restart()
    {   
        scoreText.gameObject.SetActive(true);
        stopRestartText.gameObject.SetActive(true);
        isGameOver = false;
        Time.timeScale = 1f;
        Player.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}