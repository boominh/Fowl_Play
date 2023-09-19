using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Projectile targets object with tag "Player"
// Collision with Player, reflector and enemies
// Destroyed if out of frame

public class EnemyProjectile : MonoBehaviour
{
    public float projectileSpeed;

    public GameObject reflectEDProjectile;

    GameObject target;
    Vector3 direction;
    Vector3 position;

    float width;
    float height;

    void Start()
    {
        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;

        target = GameObject.FindGameObjectWithTag("Player");
        
        direction = target.transform.position - transform.position;
        direction.Normalize();
    }
    void Update()
    {
        // Maketh movink
        gameObject.transform.position += direction * projectileSpeed * Time.deltaTime;
        gameObject.transform.Rotate(0, 0, 360 * Time.deltaTime);

        // Destroys projectile if out of frame
        position = transform.position;
        if (position.x <= -width || position.x >= width)  {Destroy(gameObject);}
        if (position.y <= -height|| position.y >= height) {Destroy(gameObject);}
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Collision with reflector
        if (other.gameObject.GetComponent<ReflectProjectile>() != null)
        {
            Instantiate(reflectEDProjectile, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        // Collision with player
        if (other.gameObject == target)
        {
            other.gameObject.SetActive(false);
            //FindObjectOfType<SceneHandler>().GoEndScreen();
        }

        /*Collision with enemy
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }*/
    }
}
