using UnityEngine;

public class Meteor : MonoBehaviour
{
    public MeteorSize poolSize;
    public float speed = 2f;
    public Vector3 moveDirection = Vector3.down;

    // Inicializar un meteor
    public void Activate(Vector3 position, Vector3 direction, MeteorSize size)
    {
        transform.position = position;
        moveDirection = direction.normalized;
        poolSize = size;

        if(size == MeteorSize.Large)
            speed = 6f;
        else
            speed = 10f;
    }

    // desactivar cuando sale del mapa
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > 30f || Mathf.Abs(transform.position.y) > 30f)
            MeteorPool.Instance.Return(gameObject, poolSize);
    }

    public void TakeDamage()
    {
        if (poolSize == MeteorSize.Large)
            Split();       

        MeteorPool.Instance.Return(gameObject, poolSize);
    }

    // 
    void Split()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject child = MeteorPool.Instance.Get(MeteorSize.Small);


            float angle;

            if(i == 0)
                angle = 30f;
            else
                angle = -30f;
            Vector3 newDir = Quaternion.Euler(0, 0, angle) * moveDirection;

            child.GetComponent<Meteor>().Activate(transform.position,
            newDir.normalized,MeteorSize.Small);
        }
    }

    //recibir damage si se 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }
}