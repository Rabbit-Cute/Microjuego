using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject player;
    public GameObject spawner;

    private bool started = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI stopRestartText;

    void Start()
    {
        Time.timeScale = 0f;
        player.SetActive(false);
        spawner.SetActive(false);
        scoreText.gameObject.SetActive(false); // Esconder el texto de puntuación al inicio
        stopRestartText.gameObject.SetActive(false); // Esconder el texto de Pausa al inicio
    }

    void Update()
    {
        if (!started && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    void StartGame()
    {   
        started = true;
        startCanvas.SetActive(false);
        player.SetActive(true);
        spawner.SetActive(true);
        scoreText.gameObject.SetActive(true); // Mostrar el texto de puntuación al iniciar el juego
        stopRestartText.gameObject.SetActive(true); // Mostrar el texto de Pausa al iniciar el juego
        Time.timeScale = 1f;                  
    }
}