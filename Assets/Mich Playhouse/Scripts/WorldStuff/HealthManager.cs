using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    float playerHealth = 3;
    float ducklingsHealth = 15;
    float mommaHealth = 15;

    float playerHPstart;
    float ducklingsHPstart;
    float mommaHPstart;

    public Image playerHealthBar;
    public Image ducklingsHealthBar;
    public Image mommaHealthBar;


    void Start()
    {
        playerHPstart = playerHealth;
        ducklingsHPstart = ducklingsHealth;
        mommaHPstart = mommaHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //playerHealthBar.fillAmount = playerHealth/playerHPstart;
        //ducklingsHealthBar.fillAmount = ducklingsHealth/ducklingsHPstart;
        //mommaHealthBar.fillAmount = mommaHealth/mommaHPstart;
    }

    public void PlayerOuchie()
    {
        playerHealth -= 1;
        //if (playerHealth <= 0) 
        //{
            
        //}
    }

    public void DucklingOuchie()
    { 
        ducklingsHealth -= 1;
        if (ducklingsHealth <= 0)
        {
            //whatever happens when die
        }
    }
    public void MommaOuchie()
    {
        mommaHealth -= 1;
        if (mommaHealth <= 0)
        {
            //whatever happens when die
        }
    }
}