using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float zVel;

    [SerializeField]
    GameObject EnemyA;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    void Controller()
    {
        if (transform.position.z > 40)
        {
            zVel *= -1;
        }

        if (transform.position.z < -25)
        {
            zVel *= -1;
        }

        transform.position += new Vector3(0f, 0f, zVel);
    }
}