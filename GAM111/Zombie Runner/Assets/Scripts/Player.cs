using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject myPlayer;

    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    Transform BarrelExit;

    [SerializeField]
    float mySpeed;

    [SerializeField]
    Animator animator;

    Rigidbody thePlayer;

    [SerializeField]
    float myHealth;

    [SerializeField]
    float mouseSpeed;

    float horzLook;

    float vertLook;

    int Death = 4;

    int Survive = 3;

    // Use this for initialization
    void Start()
    {
        thePlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();

        if (myHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(Death);
        }
    }

    void Controls()
    {
        if (Input.GetKey(KeyCode.W))
        {
            thePlayer.velocity += new Vector3(myPlayer.transform.forward.x, 0.0f, myPlayer.transform.forward.z) * mySpeed;      
        }

        if (Input.GetKey(KeyCode.S))
        {
            thePlayer.velocity += new Vector3(-myPlayer.transform.forward.x, 0.0f, -myPlayer.transform.forward.z) * mySpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            thePlayer.velocity += new Vector3(-myPlayer.transform.right.x, 0.0f, -myPlayer.transform.right.z) * mySpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            thePlayer.velocity += new Vector3(myPlayer.transform.right.x, 0.0f, myPlayer.transform.right.z) * mySpeed;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, BarrelExit.position, Quaternion.identity);

            animator.SetBool("Fire", true);
        }
        else
        {
            animator.SetBool("Fire", false);
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Finish"))
        {
            SceneManager.LoadScene(Survive);
        }
    }
    void OnCollisionStay(Collision hit)
    {
        if (hit.gameObject.tag.Equals("Enemy"))
        {
            myHealth -= 0.5f;
            print(myHealth);
        }      
    }
}