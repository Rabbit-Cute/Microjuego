using UnityEngine;

public class Player : MonoBehaviour
{
    // Ajuste del sensación de movimiento del jugador
    public float thrustForce = 20f;
    public float rotationSpeed = 120f;

    public GameObject Gun, BulletPrefab; // Prefab de la bala

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

    private void Update()
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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletPrefab, Gun.transform.position, Quaternion.identity); // Instanciar la bala en la posición del Gun
            Bullet balaScript = bullet.GetComponent<Bullet>(); // Obtener el script de la bala
            balaScript.targetVector = transform.right; // Asignar la dirección de la bala según la dirección del jugador
        }
    }

    // TODO: 飞机摧毁代码 ,碰到陨石就会摧毁
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Meteor"))
        {
            //碰到陨石后执行的代码,应该是结束游戏(?)
        }
    }
}
