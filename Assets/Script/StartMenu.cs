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
        Time.timeScale = 0f;                  // Freeze the game
        player.SetActive(false);
        spawner.SetActive(false);
        scoreText.gameObject.SetActive(false);
        stopRestartText.gameObject.SetActive(false);
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
        scoreText.gameObject.SetActive(true);
        stopRestartText.gameObject.SetActive(true);
        Time.timeScale = 1f;                  
    }
}