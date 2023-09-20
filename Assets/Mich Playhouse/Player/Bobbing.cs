using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    float frequency = 5;
    float amplitude = 0.05f;

    float timer;

    // Update is called once per frame
    void Update()
    { 
        float posY = Mathf.Sin(timer*frequency) * amplitude;

        transform.localPosition =  new Vector2 (0, posY);
        timer += Time.deltaTime;
    }
}