using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.UIElements;
using UnityEngine;

public class MamaReflectProjectile : MonoBehaviour
{
    public GameObject mamaReflectProjectile;
    float projectileSpeed = 15f;

    float spinSpeed;
    Vector3 direction;
    Vector3 position;

    float width;
    float height;


    // Start is called before the first frame update
    void Start()
    {

        width = Camera.main.orthographicSize * Camera.main.aspect; //kamerans ramar 
        height = Camera.main.orthographicSize;

        direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        direction.Normalize();

    }

    // Update is called once per frame
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

    //mommaOuchie()
    //trigga animation
}
