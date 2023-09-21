using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaIsShooting : MonoBehaviour
{

    public GameObject ProjectileMama;

    float mamaFrequency = 5f;
    float mamaAmplitude = 0.05f; //Amplitud är ett annat ord för svängningsvidd/omfattning/vidd av mågot, i detta fall svävandet på y axeln - upp och ner.
                                 //vi sätter 0.05 ex för att objektet ska få en finare sväv effekt. 

    float timer;



    float width;
    float height;
    
    float fireTimer;
    float fireRate = 1.5f;
    public Transform bulletPoint;

    //float x;
    //float y;
    
    float mamaWalkTime;
    float mamaWalkTimer;
    bool mamaStartsKilling = false;
    Vector3 mamaStartPosition;
    Vector3 mamaEndPosition;
  

    // Start is called before the first frame update
    void Start()
    {

       mamaStartPosition=transform.position;
      
      

        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;


        fireTimer = fireRate;

        mamaEndPosition.x = 4f;
        mamaEndPosition.y = 0f;
        mamaEndPosition = new Vector3 (mamaEndPosition.x, mamaEndPosition.y, 0);

        mamaWalkTime = 3f;

        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        float pY = Mathf.Sin(timer * mamaFrequency) * mamaAmplitude;
        transform.localPosition = new Vector2(0, pY);
        timer += Time.deltaTime;


        if (fireTimer > fireRate && mamaStartsKilling) //ska skjuta om mamastartkilling är lika med true och fireTimern är högre än fireRaten. 
        {
            
            MamaShooting();
         

            //resetar fireTimern för varje shoot. 
            /* MamaShooting();*/ // kallar på funktionen
        }

        // Make mama walk to her position
        if (transform.position != mamaEndPosition)
        {
            mamaWalkTimer += Time.deltaTime;
            float t = Mathf.Clamp01(mamaWalkTimer / mamaWalkTime);

            Vector3 mamasNewPosition = Vector3.Lerp(mamaStartPosition, mamaEndPosition, t); //mamasNewPosition nya position är startPositone  
            transform.position = mamasNewPosition;
        }

      
        // When to start shooting
        if (transform.position == mamaEndPosition)
        {
            mamaStartsKilling = true;
        }

        fireTimer += Time.deltaTime;
    }

    void MamaShooting()
    {
       
        GameObject mamaBullet = Instantiate(ProjectileMama, bulletPoint.position, transform.rotation); // instantierar projctilen hos mama, bulletPoint = startpositionen på maman/objektet där skottet ska ut.
        fireTimer = 0;

        // tranform.rotation = rotation. 
        //Rigidbody2D projectile = ProjectileMama.GetComponent<Rigidbody2D>();
        //projectile.velocity = bulletPoint.up * fireRate;


    }
   

}


