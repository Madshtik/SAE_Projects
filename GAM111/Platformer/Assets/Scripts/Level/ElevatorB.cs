using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorB : MonoBehaviour
{
    [SerializeField]
    float yVelB;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 60f)
        {
            yVelB *= -1;
        }

        if (transform.position.y > 132f)
        {
            yVelB *= -1;
        }

        transform.position += new Vector3(0f, yVelB, 0f);
    }
}