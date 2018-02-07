using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    Transform MyTarget;

    [SerializeField]
    GameObject Projectile;

    [SerializeField]
    Transform BarrelExit;

    [SerializeField]
    Transform Head;

    [SerializeField]
    float TurretRange;

    [SerializeField]
    float Firerate;

    float FireAgain = 0f;

    [SerializeField]
    Animator animator;

    [SerializeField]
    AudioSource Shoot;

    public string MyEnemyTag = "Enemy";

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SearchTarget", 0f, .02f);
    }

    // Update is called once per frame
    void Update()
    {
        FireAgain -= Time.deltaTime;

        transform.LookAt(MyTarget);

        if (FireAgain <= 0f)
        {
            Fire();
            FireAgain = 1f / Firerate;
        }   
    }

    void SearchTarget()
    {
        GameObject[] Target = GameObject.FindGameObjectsWithTag(MyEnemyTag);

        GameObject MyNewTarget = null;

        float ClosestDis = Mathf.Infinity;

        foreach (GameObject target in Target)
        {
            float DistanceBetween = Vector3.Distance(transform.position, target.transform.position);
            if (DistanceBetween < ClosestDis)
            {
                ClosestDis = DistanceBetween;
                MyNewTarget = target;
            }
        }

        if (MyNewTarget != null && ClosestDis <= TurretRange)
        {
            Shoot.Play();
            MyTarget = MyNewTarget.transform;
            animator.SetBool("Fire", true);
            print("Found One!");
        }
        else
        {
            MyTarget = null;
            animator.SetBool("Fire", false);
        }
    }

    void Fire()
    {
        GameObject MyProjectile = (GameObject)Instantiate(Projectile, BarrelExit.position, BarrelExit.rotation);
        Bullet projectile = MyProjectile.GetComponent<Bullet>();

        if (projectile != null)
        {
            projectile.TheTarget(MyTarget);
        }
    }
}