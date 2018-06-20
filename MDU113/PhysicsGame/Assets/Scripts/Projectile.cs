using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    GameObject myDestination;
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    GameObject Enemy;
    [SerializeField]
    Transform myProjectile;

    [SerializeField]
    Text myPositiontxt;
    [SerializeField]
    Text mySpeedtxt;
    [SerializeField]
    Text enemyHealthtxt;

    float explosionNumber = 0;
    float targetRange;
    int myDamage = 20;

    //Variables that the projectile takes into account for it to launch and after launch
    float gravity = Physics.gravity.y * -1;
    float velHorz;
    float velVert;
    float flightTime;
    [Range(150.0f, 250.0f)]
    public float myForce;
    [Range(10.0f, 75.0f)]
    public float launchAngle;
    
    // Use this for initialization
    void Start()
    {
        VelocityCalc();
    }
    
    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();
        Explosion();
        
        //Texts that will update the UI text in game when the projectile moves - since I made them into prefabs, they only update when the game ends
        myPositiontxt.text = "Position: " + new Vector2(myProjectile.position.y, myProjectile.position.z).ToString("00");
        mySpeedtxt.text = "Speed: " + myForce.ToString("00");
    }

    void VelocityCalc() //Makes the necessary calculations for the projectile's horizontal and vertical velocities
    {
        velHorz = Mathf.Sqrt(myForce) + Mathf.Cos(launchAngle * Mathf.Deg2Rad);
        velVert = Mathf.Sqrt(myForce) + Mathf.Sin(launchAngle * Mathf.Deg2Rad);
        myProjectile.rotation = Quaternion.LookRotation(myDestination.transform.position - myProjectile.position);
        flightTime = 0f;
    }

    void LaunchProjectile() //Launches the projectile
    {
        if (myProjectile.position.y >= 46.0f && myProjectile.position.z <= 73.5f)
        {
            myProjectile.Translate(0, (velVert - (gravity * flightTime)) * Time.deltaTime, velHorz * Time.deltaTime);
            flightTime += Time.deltaTime;
        }
    }

    public void Explosion() //Destroys the Projectile, instantiates a particle system that looks like a cluster of explosions, decreases the enemy health if it's within
                            //If statment range
    {
        if (myProjectile.position.y <= 46.0f && explosionNumber <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, myProjectile.position, Quaternion.identity);
            explosionNumber++;
        }

        targetRange = Vector3.Distance(myProjectile.position, Enemy.transform.position);
        Enemy MyEnemy = Enemy.GetComponent<Enemy>();
        MyEnemy.myHealth = 10;
        enemyHealthtxt.text = "Enemy Health: " + MyEnemy.myHealth.ToString("00");

        if (targetRange <= 0f && targetRange <= 9f && myProjectile.position.y <= 46.0f)
        {
            MyEnemy.myHealth -= myDamage;
            enemyHealthtxt.text = "Enemy Health: " + MyEnemy.myHealth.ToString("00");
        }
        else if (targetRange >= 10f && targetRange <= 14f && myProjectile.position.y <= 46.0f)
        {
            MyEnemy.myHealth -= myDamage / (int)(targetRange * targetRange);
            print(MyEnemy.myHealth);
            enemyHealthtxt.text = "Enemy Health: " + MyEnemy.myHealth.ToString("00");
        }

        else if (targetRange >= 15f && targetRange <= 19f && myProjectile.position.y <= 46.0f)
        {
            MyEnemy.myHealth -= myDamage / (int)(targetRange * targetRange);
            print(MyEnemy.myHealth);
            enemyHealthtxt.text = "Enemy Health: " + MyEnemy.myHealth.ToString("00");
        }

         else if (targetRange >= 20f && targetRange <= 24f && myProjectile.position.y <= 46.0f)
        {
            MyEnemy.myHealth -= myDamage / (int)(targetRange * targetRange);
            print(MyEnemy.myHealth);
            enemyHealthtxt.text = "Enemy Health: " + MyEnemy.myHealth.ToString("00");
        }       

        if (MyEnemy.myHealth <= 0)
        {
            Destroy(Enemy);
        }
    }
}