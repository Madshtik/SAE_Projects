using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    int MainMenu = 0;
    int Briefing = 1;
    int Tutorial = 2;
    int DayLevel = 3;
    int LevelSelect = 4;
    int SecondBriefing = 5;
    int NightLevel = 6;
    int Victory = 7;
    int Defeat = 8;

    public void Begin()
    {
        SceneManager.LoadScene(Briefing);
    }

    public void Controls()
    {
        SceneManager.LoadScene(Tutorial);
    }

    public void Play()
    {
        SceneManager.LoadScene(DayLevel);
    }

    public void LevelChoose()
    {
        SceneManager.LoadScene(LevelSelect);
    }

    public void ToBrief2()
    {
        SceneManager.LoadScene(SecondBriefing);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(NightLevel);
    }

    public void Win()
    {
        SceneManager.LoadScene(Victory);
    }

    public void Lose()
    {
        SceneManager.LoadScene(Defeat);
    }

    public void TitleScene()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void Quit()
    {
        Application.Quit();
        print("All is lost!");
    }
}