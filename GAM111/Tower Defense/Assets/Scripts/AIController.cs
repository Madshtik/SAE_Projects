using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent EnemyAgent;

    [SerializeField]
    float MyHealth;
    // Use this for initialization
    void Start()
    {
        GameObject MyTarget = GameObject.FindGameObjectWithTag("Base");
        GetComponent<NavMeshAgent>();
        EnemyAgent.SetDestination(MyTarget.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.tag.Equals("Bullet"))
        {
            MyHealth -= 1.0f;
            if (MyHealth <= 0f)
            {
                Destroy(gameObject);
            }           
        }
        else 
        if (Hit.gameObject.tag.Equals("Flame"))
        {
            MyHealth -= .5f;
            if (MyHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
        else
        if (Hit.gameObject.tag.Equals("Electricity"))
        {
            MyHealth -= 20f;
            if (MyHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
        else
        if (Hit.gameObject.tag.Equals("IonBolt"))
        {
            MyHealth -= 10f;
            if (MyHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}