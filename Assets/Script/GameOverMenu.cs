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

        scoreText.gameObject.SetActive(false); // Esconder el texto de puntuación al mostrar el menú de Game Over
        stopRestartText.gameObject.SetActive(false); // Esconder el texto de Pausa al mostrar el menú de Game Over
    }

    public void Restart()
    {   
        scoreText.gameObject.SetActive(true); // Mostrar el texto de puntuación al reiniciar el juego
        stopRestartText.gameObject.SetActive(true); // Mostrar el texto de Pausa al reiniciar el juego
        isGameOver = false;
        Time.timeScale = 1f;
        Player.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}