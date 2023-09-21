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
    public void PlayBossFight()
    {
        SceneManager.LoadScene("BossFight");
    }
    public void LoadVictoryScreen()
    {
        //SceneManager.LoadScene("");
    }
    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    public void LoadCredits()
    {
        //SceneManager.LoadScene("");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
