using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala
    public float maxlifeTime = 5f; // Tiempo de vida
    public Vector2 targetVector; // Dirección de la bala, que depende del ship

    void Start()
    {
        // Destruir la bala después de un tiempo
        Destroy(gameObject, maxlifeTime);
    }

    void Update()
    {
        // Movimiento de la bala hacia la dirección del target
        transform.Translate(targetVector * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Meteor"))
        {
            IncrementScore(); // Incrementar el puntaje
            Destroy(collision.gameObject); // Destruir el meteorito
            Destroy(gameObject); // Destruir la bala
        }
    }

    private void IncrementScore()
    {
        Player.score += 50; // Incrementar el puntaje en 50
        Debug.Log(Player.score); // Mostrar el puntaje en la consola
        UpdateScoreText(); // Actualizar el texto del score
    }

    private void UpdateScoreText()
    {
        // Buscar el objeto ScoreText en la escena
        GameObject scoreTextObject = GameObject.FindGameObjectWithTag("score");
        scoreTextObject.GetComponent<TextMeshProUGUI>().text = "Score: " + Player.score; // Actualizar el texto del score
    }
}
