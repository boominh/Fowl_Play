using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaIsShooting : MonoBehaviour
{

    public GameObject ProjectileMama;

    Animator animator;


    float mamaFrequency = 3f;
    float mamaAmplitudeX = 1f;
    float mamaAmplitude = 3f; //Amplitud är ett annat ord för svängningsvidd/omfattning/vidd av mågot, i detta fall svävandet på y axeln - upp och ner.
                              //vi sätter 0.05 ex för att objektet ska få en finare sväv effekt. 

    float timer;
    float timeDelay = 0;

    int MP = 1; // MP = MovePattern


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
    Vector3 mamasNewPosition;


    // Start is called before the first frame update
    void Start()
    {

        mamaStartPosition = transform.position;



        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;


        fireTimer = fireRate;

        mamaEndPosition.x = 4f;
        mamaEndPosition.y = 0f;
        mamaEndPosition = new Vector3(mamaEndPosition.x, mamaEndPosition.y, 0);

        mamaWalkTime = 3.5f;

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


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

            mamasNewPosition = Vector3.Lerp(mamaStartPosition, mamaEndPosition, t); //mamasNewPosition nya position är startPositone  
            transform.position = mamasNewPosition;
        }


        // When to start shooting
        if (transform.position == mamaEndPosition)
        {
            mamaStartsKilling = true;


            if (timeDelay >= 1f && MP == 0)
            {
                float posY = Mathf.Sin(timer * mamaFrequency) * mamaAmplitude;
                float posX = Mathf.Cos(timer * mamaFrequency) * mamaAmplitudeX;
                posX = mamaEndPosition.x;

                transform.localPosition = new Vector2(posX, posY);
            }

            timeDelay += Time.deltaTime;


            timer += Time.deltaTime;

            if (timeDelay > 1f && MP == 1)
            {


                float posY = Mathf.Sin(timer * mamaFrequency) * mamaAmplitude;
                float posX = Mathf.Cos(timer * mamaFrequency) * mamaAmplitudeX;
                posX += mamaEndPosition.x;

                transform.localPosition = new Vector2(posX, posY);


            }

            if (timeDelay > 1f && MP == 2)
            {

                float posY = Mathf.Cos(timer * mamaFrequency) * mamaAmplitude;
                float posX = Mathf.Sin(timer * mamaFrequency) * mamaAmplitudeX;
                posX += mamaEndPosition.x;

                transform.localPosition = new Vector2(posX, posY);


            }

            if (timeDelay > 1f && MP == 3)
            {

                float posY = Mathf.Sin(timer * mamaFrequency) * mamaAmplitude;
                float posX = Mathf.Sin(timer * mamaFrequency) * mamaAmplitudeX;
                posX += mamaEndPosition.x;

                transform.localPosition = new Vector2(posX, posY);


            }

            if (timeDelay > 1f && MP == 4)
            {
                float posY = Mathf.Cos(timer * mamaFrequency) * mamaAmplitude;
                float posX = -Mathf.Cos(timer * mamaFrequency) * mamaAmplitudeX;
                posX += mamaEndPosition.x;

                transform.localPosition = new Vector2(posX, posY);
            }

            fireTimer += Time.deltaTime;
        }

        void MamaShooting()
        {
            fireRate = Random.Range(0.5f, 1.5f);
            Instantiate(ProjectileMama, bulletPoint.position, transform.rotation); // instantierar projctilen hos mama, bulletPoint = startpositionen på maman/objektet där skottet ska ut.
            fireTimer = 0;

            // tranform.rotation = rotation. 
            //Rigidbody2D projectile = ProjectileMama.GetComponent<Rigidbody2D>();
            //projectile.velocity = bulletPoint.up * fireRate;
        }
    }
    public void AddMP()
    {
        MP++;
        MP = MP % 5;
    }

    public void PlayMamaOuchie()
    {
        animator.SetTrigger("ouchie");
    }
}


