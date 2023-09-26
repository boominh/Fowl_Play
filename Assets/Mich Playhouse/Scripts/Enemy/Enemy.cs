using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    Animator animator;

    float randomX;
    float randomY;

    float width;
    float height;
    
    float walkTime;
    float walkTimer;
    
    float fireRate;
    float fireRateTimer;

    bool okToShoot = false;

    Vector3 shootingPosition;
    Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        walkTime = Random.Range(0.5f, 1f);
        animator = GetComponent<Animator>();
      
        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;

        randomX = Random.Range(width/2, width);
        randomY = Random.Range(-height + 1, height - 1);
        shootingPosition = new Vector3(randomX, randomY);

        // Enables duck to fire as soon as shootingPosition is reached
        fireRateTimer = fireRate;
    }

    void Update()
    {
        if (transform.position != shootingPosition)
        {
            GoToShootingPosition();
        }

        if (transform.position == shootingPosition)
        {
            okToShoot = true;
        }

        if (okToShoot)
        {
            EnemyFire();
        }

        fireRateTimer += Time.deltaTime;
    }

    private void GoToShootingPosition()
    {
        walkTimer += Time.deltaTime;
        float t = Mathf.Clamp01(walkTimer / walkTime);

        Vector3 newPosition = Vector3.Lerp(startingPosition, shootingPosition, t);
        transform.position = newPosition;
    }

    private void EnemyFire()
    {
        if (fireRateTimer > fireRate)
        {
            fireRateTimer = 0;
            fireRate = Random.Range(2, 4);

            animator.Play("duck_attack");
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}