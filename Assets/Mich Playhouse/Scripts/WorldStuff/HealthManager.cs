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

    PlayerAnimations playerAnimations;

    void Start()
    {
        playerHPstart = playerHealth;
        ducklingsHPstart = ducklingsHealth;
        mommaHPstart = mommaHealth;

        playerAnimations = FindObjectOfType<PlayerAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.fillAmount = playerHealth/playerHPstart;
        ducklingsHealthBar.fillAmount = ducklingsHealth/ducklingsHPstart + 0.1f;
        //mommaHealthBar.fillAmount = mommaHealth/mommaHPstart;
    }

    public void PlayerOuchie()
    {
        playerHealth -= 1;
        playerAnimations.PlayerOuchieAnim();

        print(playerHealth);

        if (playerHealth <= 0)
        {
            //GameObject.FindObjectOfType<SceneHandler>().LoadLoseScreen();
        }
    }

    public void DucklingOuchie()
    { 
        ducklingsHealth -= 1;
        print(ducklingsHealth);
    }
    public void MommaOuchie()
    {
        mommaHealth -= 1;
        GameObject.FindObjectOfType<MamaIsShooting>().AddMP();
        if (mommaHealth <= 0)
        {
            //whatever happens when die
        }
    }
}
