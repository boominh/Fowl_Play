using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;

    float walkDuration = 0.5f;
    float randomX;
    float randomY;
    float width;
    float height;
    float fireTimer;
    float elapsedTime;
    public float fireRate;
    

    bool startBlasting = false;
    Vector3 shootingPosition;
    Vector3 startingPosition;
    //Vector3 movementVector;

    void Start()
    {
        startingPosition = transform.position;
      
        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;

        randomX = Random.Range(width/2, width);
        randomY = Random.Range(-height + 1, height - 1);
        shootingPosition = new Vector3(randomX, randomY); //insideunitcirle letur
        
        fireTimer = fireRate; //enables duck to fire as soon as shootingPosition is reached
    }
    void Update()
    {
        if (fireTimer > fireRate && startBlasting) 
        {
            fireTimer = 0;
            Instantiate(projectile, transform.position, transform.rotation);
        }

        if (transform.position != shootingPosition)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / walkDuration);

            Vector3 newPosition = Vector3.Lerp(startingPosition, shootingPosition, t);
            transform.position = newPosition;
        }

        if (transform.position == shootingPosition)
        {
            startBlasting = true;
        }

        fireTimer += Time.deltaTime;
    }
}
