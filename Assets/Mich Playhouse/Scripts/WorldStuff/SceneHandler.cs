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
    }
    public void PlayBossFight()
    {
        SceneManager.LoadScene("BossFight");
    }
    public void LoadVictoryScreen()
    {
        SceneManager.LoadScene("Won + Credits");
    }
    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
