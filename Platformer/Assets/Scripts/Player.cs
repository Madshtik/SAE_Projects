using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public Rigidbody Jump;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, 0f, Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0f, 0f, Speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(Speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(Speed, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump.AddForce(new Vector3(0, 400, 0));
            Jump.velocity = new Vector2(Mathf.Clamp(Jump.velocity.x, -1, 1), Mathf.Clamp(Jump.velocity.y, 1, 1));
        }
    }
}