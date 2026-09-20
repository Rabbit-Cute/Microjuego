using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 10; // Velocidad de la bala
    public float maxlifeTime = 5; // Tiempo de vida
    public Vector3 targetVector; // Dirección de la bala, que depende del ship

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject); // Destruir el enemigo al colisionar con la bala
            Destroy(gameObject); // Destruir la bala al colisionar con un enemigo
        }
    }
}
