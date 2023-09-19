using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectProjectile : MonoBehaviour
{
    float selfDestructTimer = 0.3f;
    float speed = 2f;

    Vector3 moveForward;

    Transform player;

    void Start()
    {
        // Self destruct with timer, finds object with "Player" tag
        Destroy(gameObject, selfDestructTimer);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // "Offset" so it no spawn inside player
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        direction.Normalize();
        direction *= 0.5f;

        // Moves forward relative to the player
        moveForward += transform.right * speed * Time.deltaTime;
        transform.position = player.position + direction + moveForward;
        gameObject.transform.Rotate(0, 0, 1080 * Time.deltaTime);
    }
}
