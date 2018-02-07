using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour
{
    //delegates can have a return and an input, but has to match
    public delegate void HuntedEvent();
    public static event HuntedEvent Hunt;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hunt != null)
        {
            Hunt();           
        }
    }
}