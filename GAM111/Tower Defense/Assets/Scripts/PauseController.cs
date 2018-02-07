using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    Transform PauseCanvas;
    [SerializeField]
    Transform TurretMenu;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (PauseCanvas.gameObject.activeInHierarchy == false)
        {
            Time.timeScale = 0f;
            PauseCanvas.gameObject.SetActive(true);
            TurretMenu.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            PauseCanvas.gameObject.SetActive(false);
            TurretMenu.gameObject.SetActive(true);
        }
    }
}