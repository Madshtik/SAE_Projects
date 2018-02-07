using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    GameObject[] waypoints;

    int index = 0;

    [SerializeField]
    Transform Enemy;

    float mySpeed = .05f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = waypoints[index].transform.position - transform.position;
        dir.Normalize();
        Enemy.position += dir * mySpeed;

        float dist = Vector3.Distance(Enemy.position, waypoints[index].transform.position);

        if (dist <= 0.1f)
        {
            index++;
            if (index >= 4)
            {
                index = 0;
            }
        }
    }
}