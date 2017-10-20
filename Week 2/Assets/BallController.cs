using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float roll;
    public Rigidbody Jump;
    public GameObject Ball;
    public Light Spotlight;

    void OnCollisionEnter(Collision collision)
    {
        MeshRenderer m = collision.gameObject.GetComponent<MeshRenderer>();
        m.material.color = Color.black;
        Spotlight.color = Color.yellow;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, 0f, roll);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0f, 0f, roll);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(roll, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(roll, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump.AddForce(new Vector3(0, 400, 0));
            Jump.velocity = new Vector2(Mathf.Clamp(Jump.velocity.x, -1, 1), Mathf.Clamp(Jump.velocity.y, 1, 1));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * roll, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * roll, Space.World);
        }
    }
}