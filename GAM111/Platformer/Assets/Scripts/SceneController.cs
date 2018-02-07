using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Begin()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        SceneManager.LoadScene(2);
    }

    public void Play()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
        print("We're Doomed...");
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}