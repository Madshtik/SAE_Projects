using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBolt : MonoBehaviour
{
    [SerializeField]
    float BoltRange = 2.0f;

    public Rigidbody Bolt;

    [SerializeField]
    float BoltSpeed;

    Vector3 BulletDir;
    GameObject myPlayer;
    // Use this for initialization
    void Start()
    {
        myPlayer = (GameObject.Find("Player"));
        BulletDir = new Vector3(myPlayer.transform.forward.x, myPlayer.transform.forward.y, myPlayer.transform.forward.z);
    }

    // Update is called once per frame
    void Update()
    {
        BoltDeath();
        Bolt.AddForce(BulletDir * BoltSpeed);
    }

    void BoltDeath()
    {
        Destroy(gameObject, BoltRange);
    }
}