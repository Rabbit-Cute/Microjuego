using UnityEngine;

public class Meteor : MonoBehaviour
{

    int health = 1;
    float speed = 2f;
    float size = 1f;
    public Vector3 moveDirection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //test
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

    }
}
