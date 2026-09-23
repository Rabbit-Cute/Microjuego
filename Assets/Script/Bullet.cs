using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala
    public float maxlifeTime = 5f; // Tiempo de vida
    public Vector2 targetVector; // Dirección de la bala, que depende del ship

    public void Activate(Vector2 direction)
    {
        targetVector = direction.normalized;
        CancelInvoke();
        Invoke(nameof(Recycle), maxlifeTime);
    }

    void Update()
    {
        // Movimiento de la bala hacia la dirección del target
        transform.Translate(targetVector * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Meteor"))
        {
            Meteor m = other.GetComponent<Meteor>();
            if (m != null) m.TakeDamage();

            IncrementScore(); // Incrementar el puntaje
            Recycle(); // Devolver la bala al pool
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

    // Devolver al pool
    void Recycle()
    {
        CancelInvoke();
        BulletPool.Instance.Return(gameObject);
    }
}