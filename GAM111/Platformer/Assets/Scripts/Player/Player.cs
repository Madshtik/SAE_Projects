using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject Eyes;

    [SerializeField]
    float Speed;

    [SerializeField]
    Rigidbody Jump;

    int JumpCount;

    [SerializeField]
    float JumpHeight;

    [SerializeField]
    float mouseSpeed;

    Rigidbody thePlayer;

    float horzLook;
    float vertLook;

    // Use this for initialization
    void Start()
    {
        thePlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    void Controls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            thePlayer.velocity += new Vector3(Eyes.transform.forward.x, 0.0f, Eyes.transform.forward.z) * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            thePlayer.velocity += new Vector3(-Eyes.transform.forward.x, 0.0f, -Eyes.transform.forward.z) * Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            thePlayer.velocity += new Vector3(-Eyes.transform.right.x, 0.0f, -Eyes.transform.right.z) * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            thePlayer.velocity += new Vector3(Eyes.transform.right.x, 0.0f, Eyes.transform.right.z) * Speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && JumpCount < 1)
        {
            Jump.AddForce(new Vector3(0, JumpHeight, 0));
            Jump.velocity = new Vector2(Mathf.Clamp(Jump.velocity.x, -1, 1), Mathf.Clamp(Jump.velocity.y, 1, 1));
            JumpCount++;
        }    
        
        horzLook += Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        vertLook += Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        if (vertLook >= 60)
        {
            vertLook = 60;
        }

        if (vertLook <= -60)
        {
            vertLook = -60;
        }

        transform.rotation = Quaternion.Euler(-vertLook, horzLook, 0);
    }

    void OnTriggerEnter(Collider Fall)
    {
        if (Fall.gameObject.tag.Equals("Killbox"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }        
    }

    void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.tag.Equals("Platform"))
        {
            JumpCount = 0;
        }

        if (Hit.gameObject.tag.Equals("Objective"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }

        if (Hit.gameObject.tag.Equals("Enemy"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
    }   
}