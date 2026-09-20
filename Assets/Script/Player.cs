using UnityEngine;

public class Player : MonoBehaviour
{
    // Ajuste del sensación de movimiento del jugador
    [SerializeField] private float thrustForce = 20f;
    [SerializeField] private float rotationSpeed = 120f;

    private Vector2 thrustDirection;
    private Rigidbody rigidbody;

    void Start()
    {
        // Referencia al componente Rigidbody
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false; // Desactivar la gravedad, para que no caiga
        transform.position = new Vector3(-18f, 0f, 0f); // Posición inicial
        transform.rotation = Quaternion.identity; // Rotación inicial
    }

    private void FixedUpdate()
    {
        // Obtener la entrada (Input) del jugador para rotación y empuje
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Vertical") * thrustForce;

        // Cáculo de la dirección de empuje, por defecto es el eje X positivo
        thrustDirection = transform.right;

        // Aplicar rotación sobre el eje Z en negativo
        transform.Rotate(Vector3.forward, -rotation);

        // Aplicar fuerza de empuje en la dirección calculada
        rigidbody.AddForce(thrust * thrustDirection);
    }

}
