using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaIsShooting : MonoBehaviour
{

    public GameObject ProjectileMama;

    float mamaFrequency = 5f;
    float mamaAmplitude = 0.05f; //Amplitud �r ett annat ord f�r sv�ngningsvidd/omfattning/vidd av m�got, i detta fall sv�vandet p� y axeln - upp och ner.
                                 //vi s�tter 0.05 ex f�r att objektet ska f� en finare sv�v effekt. 

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


        if (fireTimer > fireRate && mamaStartsKilling) //ska skjuta om mamastartkilling �r lika med true och fireTimern �r h�gre �n fireRaten. 
        {
            
            MamaShooting();
         

            //resetar fireTimern f�r varje shoot. 
            /* MamaShooting();*/ // kallar p� funktionen
        }

        // Make mama walk to her position
        if (transform.position != mamaEndPosition)
        {
            mamaWalkTimer += Time.deltaTime;
            float t = Mathf.Clamp01(mamaWalkTimer / mamaWalkTime);

            Vector3 mamasNewPosition = Vector3.Lerp(mamaStartPosition, mamaEndPosition, t); //mamasNewPosition nya position �r startPositone  
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
       
        GameObject mamaBullet = Instantiate(ProjectileMama, bulletPoint.position, transform.rotation); // instantierar projctilen hos mama, bulletPoint = startpositionen p� maman/objektet d�r skottet ska ut.
        fireTimer = 0;

        // tranform.rotation = rotation. 
        //Rigidbody2D projectile = ProjectileMama.GetComponent<Rigidbody2D>();
        //projectile.velocity = bulletPoint.up * fireRate;


    }
   

}


