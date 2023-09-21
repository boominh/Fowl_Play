using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaSpawner : MonoBehaviour
{

    public GameObject MamaSpawning;

   

    float width;
    float height;
    float timer;
   
   

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
   
}
