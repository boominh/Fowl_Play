using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    int checkPoint = 0;
    public void PlayGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void LoadPreBoss()
    {
        SceneManager.LoadScene("LoadBossFight");
    }
    public void PlayBossFight()
    {
        SceneManager.LoadScene("BossFight");
        checkPoint = 1;
    }
    public void LoadVictoryScreen()
    {
        SceneManager.LoadScene("Won + Credits");
    }
    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    public void LoadCheckPoint()
    {
        if (checkPoint == 0)
        {
            LoadGame();
        }
        if (checkPoint == 1)
        {
            LoadPreBoss();
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        checkPoint = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
