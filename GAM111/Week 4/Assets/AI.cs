using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField]
    Transform Destination;

    [SerializeField]
    NavMeshAgent myUnit;
    // Use this for initialization
    void Start()
    {
        myUnit = GetComponent<NavMeshAgent>();
        myUnit.SetDestination(Destination.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}