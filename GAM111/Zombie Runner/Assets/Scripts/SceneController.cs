using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    int MainMenu = 0;
    int Controls = 1;
    int GameScene = 2;
    int Win = 3;
    int Lose = 4;

    public void Main()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(Controls);
    }

    public void Game()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void Victory()
    {
        SceneManager.LoadScene(Win);
    }

    public void Dead()
    {
        SceneManager.LoadScene(Lose);
    }

    public void Quit()
    {
        Application.Quit();
        print("Coward!");
    }
}