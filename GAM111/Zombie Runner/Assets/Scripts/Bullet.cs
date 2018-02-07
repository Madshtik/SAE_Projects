using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float myRange;

    public Rigidbody Projectile;

    [SerializeField]
    float mySpeed;

    Vector3 BulletDir;

    GameObject MyPlayer;

    // Use this for initialization
    void Start()
    {
        MyPlayer = (GameObject.Find("Player"));
        BulletDir = new Vector3(MyPlayer.transform.forward.x, MyPlayer.transform.forward.y, MyPlayer.transform.forward.z);
    }

    // Update is called once per frame
    void Update()
    {
        MyDeath();
        Projectile.AddForce(BulletDir * mySpeed);
    }

    void MyDeath()
    {
        Destroy(gameObject, myRange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}