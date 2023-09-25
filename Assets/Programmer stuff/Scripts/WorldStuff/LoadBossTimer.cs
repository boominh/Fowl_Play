using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBosstimer : MonoBehaviour
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

        if (Input.GetKey(KeyCode.Space))
        {
            GameObject.FindObjectOfType<SceneHandler>().PlayBossFight();
        }
        if (timer > 5)
        {
            GameObject.FindObjectOfType<SceneHandler>().PlayBossFight();
        }
    }
}
