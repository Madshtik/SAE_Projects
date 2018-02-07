using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFlee : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent enemyAgent;

    [SerializeField]
    float myHealth;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         
    }


    void OnTriggerEnter(Collider detected)
    {
        if (detected.gameObject.tag.Equals("Player"))
        {
            GameObject building = GameObject.FindGameObjectWithTag("Building");
            GetComponent<NavMeshAgent>();
            enemyAgent.SetDestination(building.transform.position);

            print("I've been followed");
        }
    }

    void OnCollisionEnter(Collision shot)
    {
        if (shot.gameObject.tag.Equals("Bullet"))
        {
            myHealth -= 1f;

            if (myHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}