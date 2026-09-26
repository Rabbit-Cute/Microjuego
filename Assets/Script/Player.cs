using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Ajuste del sensación de movimiento del jugador
    public float thrustForce = 10f;
    public float rotationSpeed = 120f;

    public GameObject Gun, BulletPrefab; // Prefab de la bala

    private Vector2 thrustDirection;
    private Rigidbody2D rigidbody;

    public float xBorderLimit = 25f;
    public float yBorderLimit = 15f;

    public static int score = 0; // Puntos iniciales del jugador
    public float tiempoSobrevivencia = 0f; // Tiempo de supervivencia del jugador
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Referencia al componente Rigidbody
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0f; // Desactivar la gravedad, para que no caiga
        transform.position = new Vector3(-18f, 0f, 0f); // Posición inicial
        transform.rotation = Quaternion.identity; // Rotación inicial
    }

    private void Update()
    {   

        if (GameOverMenu.isGameOver) return; 
        // Obtener la entrada (Input) del jugador para rotación y empuje
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Vertical") * thrustForce;

        // Cáculo de la dirección de empuje, por defecto es el eje X positivo
        thrustDirection = transform.right;

        // Aplicar rotación sobre el eje Z en negativo
        transform.Rotate(Vector3.forward, -rotation);

        // Aplicar fuerza de empuje en la dirección calculada
        rigidbody.AddForce(thrust * thrustDirection);

        // Hacer pantalla infinita
        Vector3 newPos = transform.position;
        if (newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit + 1;
        else if (newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit - 1;
        else if (newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit + 1;
        else if (newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit - 1;
        transform.position = newPos;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = BulletPool.Instance.Get();
            bullet.transform.position = Gun.transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.Activate(transform.right);
        }

        tiempoSobrevivencia += Time.deltaTime; // Incrementar el tiempo de supervivencia
        if(tiempoSobrevivencia >= 1f) // Cada segundo, incrementar el puntaje
        {
            score += 10; // Incrementar el puntaje en 10
            tiempoSobrevivencia = 0f; // Reiniciar el tiempo de supervivencia
            UpdateScoreText(); // Actualizar el texto del score
        }
    }

    // Detectar colisiones con los meteoritos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            score = 0; // Reiniciar el puntuaje
            FindFirstObjectByType<GameOverMenu>().ShowGameOver();
        }
        else
        {
            Debug.Log("He colisionado con otra cosa...");
        }
    }

    private void UpdateScoreText()
    {
        // Buscar el objeto ScoreText en la escena
        GameObject scoreTextObject = GameObject.FindGameObjectWithTag("score");
        scoreTextObject.GetComponent<TextMeshProUGUI>().text = "Score: " + score; // Actualizar el texto del score
    }
}
