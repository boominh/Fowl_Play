using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
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
        PlayerPrefs.SetInt("checkpoint", 1);
    }
    public void PlayBossFight()
    {
        SceneManager.LoadScene("BossFight");
        PlayerPrefs.SetInt("checkpoint", 1);
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
        if (PlayerPrefs.GetInt("checkpoint") == 0)
        {
            LoadGame();
        }
        if (PlayerPrefs.GetInt("checkpoint") == 1)
        {
            LoadPreBoss();
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("checkpoint", 0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            LoadMainMenu();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            QuitGame();
        }
    }
}
