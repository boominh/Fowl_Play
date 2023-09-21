using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    float playerHealth = 3;
    float ducklingsHealth = 20;
    float mommaHealth = 15;

    float playerHPstart;
    float ducklingsHPstart;
    float mommaHPstart;

    public Image playerHealthBar;
    public Image ducklingsHealthBar;
    public Image mommaHealthBar;

    SceneHandler sceneHandler;
    PlayerAnimations playerAnimations;
    PlayerSound playerSound;
    MamaIsShooting mamaAnimations;

    void Start()
    {
        playerHPstart = playerHealth;
        ducklingsHPstart = ducklingsHealth;
        mommaHPstart = mommaHealth;

        sceneHandler = FindAnyObjectByType<SceneHandler>();
        playerAnimations = FindObjectOfType<PlayerAnimations>();
        playerSound = FindObjectOfType<PlayerSound>();
        mamaAnimations = FindAnyObjectByType<MamaIsShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.fillAmount = playerHealth/playerHPstart;
        ducklingsHealthBar.fillAmount = ducklingsHealth/ducklingsHPstart + 0.1f;
        mommaHealthBar.fillAmount = mommaHealth/mommaHPstart;
    }

    public void PlayerOuchie()
    {
        playerHealth -= 1;
        playerAnimations.PlayerOuchieAnim();
        playerSound.PlayPlayerHitSound();

        if (playerHealth <= 0)
        {
            sceneHandler.LoadLoseScreen();
        }
    }

    public void DucklingOuchie()
    { 
        ducklingsHealth -= 1;
    }
    public void MommaOuchie()
    {
        mommaHealth -= 1;
        mamaAnimations.PlayMamaOuchie();
        //GameObject.FindObjectOfType<MamaIsShooting>().AddMP();
        if (mommaHealth <= 0)
        {
            sceneHandler.LoadVictoryScreen();
        }
    }
}
