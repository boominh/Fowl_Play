using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer;
    public float fireRate = 2f;

    public GameObject projectile;

    void Update()
    {
        if (timer > fireRate) 
        {
            timer = 0;
            Instantiate(projectile, transform.position, transform.rotation);
        }

        timer += Time.deltaTime;
    }
}
