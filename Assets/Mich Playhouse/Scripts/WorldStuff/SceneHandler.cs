using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void PlayBossFight()
    {
        SceneManager.LoadScene("BossFight");
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
