using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI scoreText;
    public static bool isGameOver = false; 

    public void ShowGameOver()
    {   
        isGameOver = true;
        gameOverCanvas.SetActive(true);
        scoreText.text = "Score: " + Player.score;
        Time.timeScale = 0f;
    }

    public void Restart()
    {   
        isGameOver = false;
        Time.timeScale = 1f;
        Player.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}