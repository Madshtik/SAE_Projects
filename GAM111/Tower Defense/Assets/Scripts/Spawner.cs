using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool HasTurret = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn(GameObject Turret, Vector3 Position, Vector3 Rotation)
    {
        if (!HasTurret)
        {
            Instantiate(Turret, Position, Quaternion.Euler(Rotation));
            HasTurret = true;
        }
    }
}