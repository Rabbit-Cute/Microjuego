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
        if (scoreText != null) scoreText.gameObject.SetActive(false);
        if (stopRestartText != null) stopRestartText.gameObject.SetActive(false);
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
        if (scoreText != null) scoreText.gameObject.SetActive(true);
        if (stopRestartText != null) stopRestartText.gameObject.SetActive(true);
        Time.timeScale = 1f;                  
    }
}