using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ReflectEDProjectile : MonoBehaviour
{
    float projectileSpeed = 15f;
    float spinSpeed = 360 * 5;
    
    public GameObject explosion;
    public GameObject bloodPuddle;
    
    Vector3 direction;
    Vector3 position;

    float width;
    float height;

    Vector3 duckPosition;
    quaternion duckRotation;

    void Start()
    {
        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;

        direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        direction.Normalize();
    }

    void Update()
    {
        // Maketh movink
        gameObject.transform.position += direction * projectileSpeed * Time.deltaTime;
        gameObject.transform.Rotate(0, 0, spinSpeed * Time.deltaTime);

        // Destroys projectile if out of frame
        position = transform.position;
        if (position.x <= -width || position.x >= width) { Destroy(gameObject); }
        if (position.y <= -height || position.y >= height) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            duckPosition = other.gameObject.transform.position;
            duckRotation = other.gameObject.transform.rotation;
            Destroy(other.gameObject);

            Invoke("MakeExplode", 0f);
            Invoke("MakePuddle", 0.4f);
            
            FindObjectOfType<EnemySpawner>().Enemydied();

            gameObject.SetActive(false);
        }
    }
    void MakePuddle()
    {
        GameObject newPuddle = Instantiate(bloodPuddle, duckPosition, duckRotation);
        Destroy(newPuddle, 1.5f);
    }
    void MakeExplode()
    {
        GameObject newExplosion = Instantiate(explosion, duckPosition, duckRotation);
        Destroy(newExplosion, 1);
    }
    //void MakeDie()
    //{
    //    Destroy(gameObject);
    //} 
}
