using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform Spawn;

    [SerializeField]
    Transform Spawn2;

    [SerializeField]
    GameObject EnemyA;

    [SerializeField]
    GameObject EnemyB;

    float TimetoSpawn = 10f;
    float WaveCountdown = 5f;
    float FinalWave = 0f;

    int Victory = 7;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimetoSpawn -= Time.deltaTime;
        if (TimetoSpawn <= 0f)
        {
            Spawner();
            TimetoSpawn = WaveCountdown;
            FinalWave++;
        }
        if (FinalWave >= 10)
        {
            TimetoSpawn = 70f;
            TimetoSpawn++;
            if (TimetoSpawn >= 71f)
            {
                SceneManager.LoadScene(Victory);
            }
        }      
    }

    void Spawner()
    {
        print("Bleeeeeeeeep!");
        Instantiate(EnemyA, Spawn.position, Quaternion.Euler(0f, 180, 0f));

        print("Vroom vroom, my dudes");
        Instantiate(EnemyB, Spawn2.position, Quaternion.Euler(0f, 180f, 0f));       
    }
}