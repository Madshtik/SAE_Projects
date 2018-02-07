using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorA : MonoBehaviour
{
    [SerializeField]
    float yVel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1f)
        {
            yVel *= -1;
        }

        if (transform.position.y > 63f)
        {
            yVel *= -1;
        }

        transform.position += new Vector3(0f, yVel, 0f);
    }
}