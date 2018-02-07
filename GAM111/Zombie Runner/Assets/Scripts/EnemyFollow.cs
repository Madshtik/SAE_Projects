using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent enemyAgent;

    [SerializeField]
    float myHealth;

    [SerializeField]
    Animator animator;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider detectedPlayer)
    {
        if (detectedPlayer.gameObject.tag.Equals("Player"))
        {
            GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");
            GetComponent<NavMeshAgent>();
            enemyAgent.SetDestination(thePlayer.transform.position);

            animator.SetBool("Move", true);

            print("Player Detected");
        }
        else
        {
            animator.SetBool("Move", false);
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