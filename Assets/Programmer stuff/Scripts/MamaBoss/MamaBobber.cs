using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaBobber : MonoBehaviour
{

    float mamaFrequency = 5f;
    float mamaAmplitude = 0.05f; //Amplitud �r ett annat ord f�r sv�ngningsvidd/omfattning/vidd av m�got, i detta fall sv�vandet p� y axeln - upp och ner.
                             //vi s�tter 0.05 ex f�r att objektet ska f� en finare sv�v effekt. 

    float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float pY = Mathf.Sin(timer * mamaFrequency) * mamaAmplitude;
        transform.localPosition = new Vector2(0, pY);
        timer += Time.deltaTime;


    }
}
