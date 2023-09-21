using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTimer : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            GameObject.FindObjectOfType<SceneHandler>().LoadGame();
        }

        if (timer > 29 ) 
        {
            GameObject.FindObjectOfType<SceneHandler>().LoadGame();
        }
    }
}
