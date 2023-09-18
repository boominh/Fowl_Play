using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectile targets object with tag "Player"

public class Projectile : MonoBehaviour
{
    GameObject target;
    public float projectileSpeed;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        
        direction = target.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += direction * projectileSpeed * Time.deltaTime;
    }
}
