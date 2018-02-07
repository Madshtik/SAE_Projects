using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform Target;

    [SerializeField]
    float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 Aim = Target.position - transform.position;
        float Distance = speed * Time.deltaTime;

        if (Aim.magnitude <= Distance)
        {
            Hit();
        }

        transform.Translate(Aim.normalized * Distance, Space.World);
    }

    public void TheTarget(Transform myTarget)
    {
        Target = myTarget;
    }

    void Hit()
    {
        Destroy(gameObject);
    }

}