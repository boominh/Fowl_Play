using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MamaProjectileScript : MonoBehaviour
{
    public GameObject reflectEDProjectile;
    GameObject mamasTarget;
    Vector3 bulletDirection;
    Vector3 bulletPosition;

    float bulletSpeed = 6;

    float width;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        width = Camera.main.orthographicSize * Camera.main.aspect; //Main kamerans ramar. 
        height = Camera.main.orthographicSize;

        mamasTarget = GameObject.FindGameObjectWithTag("Player"); //mamas target är gameobjeket med taggen player. 

        bulletDirection = mamasTarget.transform.position - transform.position; //bullet skjuts utifrån mama ducks position. 
        bulletDirection.Normalize();  //normaliserar bullets magnitude till 1. 

    }

    // Update is called once per frame
    void Update()
    {

        
        gameObject.transform.position += bulletDirection * bulletSpeed * Time.deltaTime; 
        gameObject.transform.Rotate(0, 0, 360 * Time.deltaTime);

        // Destroys projectile if out of frame
        bulletPosition = transform.position;
        if (bulletPosition.x <= -width || bulletPosition.x >= width) { Destroy(gameObject); }
        if (bulletPosition.y <= -height || bulletPosition.y >= height) { Destroy(gameObject); }
       

    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        // kollision med spelarens reflektor
        if (other.gameObject.GetComponent<ReflectProjectile>() != null)
        {
            Instantiate(reflectEDProjectile, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        // Collision with player
        if (other.gameObject == mamasTarget)
        {
            GameObject.FindObjectOfType<HealthManager>().PlayerOuchie();
            Destroy(gameObject);
        }



    }
}
