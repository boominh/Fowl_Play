using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02 : MonoBehaviour
{
    public GameObject projectile;
    public GameObject unblockableProjectile;

    //bool fireUnblockable = true;

    float walkDuration = 0.5f;

    float randomX;
    float randomY;
    float width;
    float height;

    float walkTimer;
    float fireTimer;
    public float fireRate;


    bool startBlasting = false;
    Vector3 shootingPosition;
    Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;

        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;

        randomX = Random.Range(width / 2, width);
        randomY = Random.Range(-height + 1, height - 1);
        shootingPosition = new Vector3(randomX, randomY); // Optimize with insideunitcircle later

        //enables duck to fire as soon as shootingPosition is reached
        fireTimer = fireRate;
    }
    void Update()
    {
        //Fire with fire rate
        if (fireTimer > fireRate && startBlasting)
        {
            fireTimer = 0;

            if (Random.Range(0, 2) == 0)
            {
                Instantiate(unblockableProjectile, transform.position, transform.rotation);
            }

            else
            {
                Instantiate(projectile, transform.position, transform.rotation);
            }
            //if (fireUnblockable == true)
            //{
            //    fireUnblockable = false;
            //    Instantiate(unblockableProjectile, transform.position, transform.rotation);
            //    return;
            //}

            //if (fireUnblockable == false)
            //{
            //    fireUnblockable = true;
            //    Instantiate(projectile, transform.position, transform.rotation);
            //    return;
            //}
        }

        // Make walk to position
        if (transform.position != shootingPosition)
        {
            walkTimer += Time.deltaTime;
            float t = Mathf.Clamp01(walkTimer / walkDuration);

            Vector3 newPosition = Vector3.Lerp(startingPosition, shootingPosition, t);
            transform.position = newPosition;
        }

        // When to start shooting
        if (transform.position == shootingPosition)
        {
            startBlasting = true;
        }

        fireTimer += Time.deltaTime;
    }
}
