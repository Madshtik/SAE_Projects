using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject myBody;

    public int myHealth;

    public Text myHealthtxt;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myHealthtxt.text = "Enemy Health: " + myHealth.ToString("00");
    }
}