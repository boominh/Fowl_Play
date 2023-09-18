using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectProjectile : MonoBehaviour
{
    public float selfDestructTimer = 0.3f;
    public float speed = 1f;

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
        // Moves forward relative to the player
        moveForward += transform.right * speed * Time.deltaTime;
        transform.position = player.position + moveForward;
    }
}
