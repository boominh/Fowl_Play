using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject reflectPrefab;

    float timer;
    float fireRate = 0.6f;

    void Update()
    {
        // Vector between mouse and player
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        
        // Make reflect
        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            transform.right = direction;
            fire();
            transform.up = Vector2.up;
            timer = 0;
        }

        timer += Time.deltaTime;
    }
    // Make spawn
    void fire()
    {
        Instantiate(reflectPrefab, transform.position, transform.rotation);
    }
}

