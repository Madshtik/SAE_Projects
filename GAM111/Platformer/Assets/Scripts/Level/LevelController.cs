using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject PlatformLongA;

    [SerializeField]
    GameObject PlatformLongB;

    [SerializeField]
    GameObject PlatformLongC;

    [SerializeField]
    float Length;

    [SerializeField]
    GameObject ElevatorA;

    [SerializeField]
    GameObject ElevatorB;

    [SerializeField]
    float ElevatorSpeed;
    [SerializeField]
    float Number;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Number; i++)
        {
            Instantiate(PlatformLongA, new Vector3(0.0f, 0.0f, i * Length), Quaternion.identity);
            Instantiate(PlatformLongB, new Vector3(0.0f, 61.88f, i * Length), Quaternion.identity);
            Instantiate(PlatformLongC, new Vector3(41.0f, 130.0f, i * Length), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}