using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaSpawner : MonoBehaviour
{

    public GameObject MamaSpawning;

    float mamaFrequency = 5f;
    float mamaAmplitude = 1f; //Amplitud är ett annat ord för svängningsvidd/omfattning/vidd av mågot, i detta fall svävandet på y axeln - upp och ner.
                              //vi sätter 0.05 ex för att objektet ska få en finare sväv effekt. 
    float timer2;

    float width;
    float height;
    float timer;
    float spawnRate = 1.2f;
    float mamaSpawnX;
    float mamaSpawnY;

    Vector3 mamaSpawnPosition;



    // Start is called before the first frame update
    void Start()
    {

        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;
        
        Instantiate(MamaSpawning, new Vector3 (width-1,0,0) , transform.rotation);

        //SpawningMama(width, 10f); //x och y vart jag vill at hon ska spawna
    }

    // Update is called once per frame
    void Update()
    {
        //if (timer >= spawnRate)
        //{
           
            //timer += Time.deltaTime;
  
            


        
      
      /*  mamaSpawnPosition = new Vector3(mamaSpawnX,mamaSpawnY,0f);*/ //specifiera vart mama ska spawna. 

        //mamaSpawnPosition = new Vector3(mamaSpawnPosition.x, mamaSpawnPosition.y, 0f);


    }
    //void SpawningMama(float mamaSpawnX, float mamaSpawnY) 
    //{
    //    Instantiate(MamaSpawning, mamaSpawnPosition, transform.rotation);
    //}
    void MamaBobbing()
    {

        float pY = Mathf.Sin(timer2 * mamaFrequency) * mamaAmplitude;
        transform.localPosition = new Vector2(0, pY);
        timer += Time.deltaTime;


    }
}
