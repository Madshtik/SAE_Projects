using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject myProjectile;

    //Two int variables that control the reload and fire capability of the player
    int reload = 1;
    int shotCount = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }
    
    void Controls() //Controls the Yellow player cube
    {
        if (Input.GetKey(KeyCode.Space) && shotCount <= 0) //An if statement to fire the projectile
        {
            Instantiate(myProjectile, transform.position, Quaternion.identity);
            shotCount++;
            reload--;
        }

        if (Input.GetKey(KeyCode.R) && reload <= 0) //An if statement to reload the cannon
        {
            reload = 1;
            shotCount = 0;
        }
    }
}