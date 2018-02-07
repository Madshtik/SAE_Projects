using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    float MyHealth = 100;
    float Damage = 1;
    MeshRenderer DamageIndicator;

    [SerializeField]
    GameObject Sphere;

    [SerializeField]
    Transform Spawn;

    // Use this for initialization
    void Start()
    {
        DamageIndicator = GetComponent<MeshRenderer>();
        Prey.Hunt += HunterDamage;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HunterDamage()
    {
        MyHealth -= Damage;
        print(MyHealth);
        if (MyHealth <= 0)
        {
            DamageIndicator.material.color = Color.black;
            Destroy(gameObject);
            Instantiate(Sphere, Spawn.position, Quaternion.identity);
            Prey.Hunt -= HunterDamage;
        }
    }
}