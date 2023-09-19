using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ReflectEDProjectile : MonoBehaviour
{
    public float projectileSpeed = 7f;
    
    public GameObject explosion;
    
    Vector3 direction;
    Vector3 position;

    float width;
    float height;

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

        // Destroys projectile if out of frame
        position = transform.position;
        if (position.x <= -width || position.x >= width) { Destroy(gameObject); }
        if (position.y <= -height || position.y >= height) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            Vector3 duckPosition = other.gameObject.transform.position;
            quaternion duckRotation = other.gameObject.transform.rotation;
            Destroy(other.gameObject);

            Instantiate(explosion, duckPosition, duckRotation);

            Destroy(gameObject);
        }
    }
}
