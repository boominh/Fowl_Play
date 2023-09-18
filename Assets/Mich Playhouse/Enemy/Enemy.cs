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
    float walkTimer;
    public float fireRate;

    bool startBlasting = false;
    Vector3 shootingPosition;
    //Vector3 movementVector;

    void Start()
    {
        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;

        randomX = Random.Range(width/2, width);
        randomY = Random.Range(-height + 1, height - 1);
        shootingPosition = new Vector3(randomX, randomY); //insideunitcirle letur

        fireTimer = fireRate;
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
            float elapsedTime = Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / walkDuration);

            Vector3 newPosition = Vector3.Lerp(transform.position, shootingPosition, t);
            transform.position = newPosition;
        }

        if (walkTimer >= walkDuration)
        {
            startBlasting = true;
        }

        fireTimer += Time.deltaTime;
        walkTimer += Time.deltaTime;
    }
}
