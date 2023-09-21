using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaBobber : MonoBehaviour
{

    float mamaFrequency = 5f;
    float mamaAmplitude = 0.05f; //Amplitud är ett annat ord för svängningsvidd/omfattning/vidd av mågot, i detta fall svävandet på y axeln - upp och ner.
                             //vi sätter 0.05 ex för att objektet ska få en finare sväv effekt. 

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
