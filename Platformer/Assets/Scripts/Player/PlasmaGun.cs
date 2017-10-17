using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaGun : MonoBehaviour
{
    [SerializeField]
    GameObject Bolt;
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlasmaShot();
    }

    void PlasmaShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Bolt, transform.position, Quaternion.identity);
        }
    }
}