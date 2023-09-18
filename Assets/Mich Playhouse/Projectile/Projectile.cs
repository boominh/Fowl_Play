using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectile targets object with tag "Player"

public class Projectile : MonoBehaviour
{
    GameObject target;
    public float projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();

        gameObject.transform.position += direction * projectileSpeed *Time.deltaTime;
    }
}
