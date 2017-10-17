using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{    
    public Transform PauseCanvas;
    
    public Transform Player;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void Paused()
    {
        if (PauseCanvas.gameObject.activeInHierarchy == false)
        {
            PauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Player.GetComponent<Player>().enabled = false;
        }
        else
        {
            PauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
            Player.GetComponent<Player>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }
    }
}