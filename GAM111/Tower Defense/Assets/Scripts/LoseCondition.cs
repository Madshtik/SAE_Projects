using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    int Defeat = 8;

    void OnCollisionEnter(Collision Explode)
    {
        if (Explode.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(Defeat);
        }
    }
}