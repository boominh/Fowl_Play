using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb2D;
    public float duckMaxSpeed = 6f;
    public float acceleration = 11f;
    public float deacceleration = 7f;

    Vector2 userInput;
    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        userInput.x = Input.GetAxisRaw("Horizontal");
        userInput.y = Input.GetAxisRaw("Vertical");
        userInput.Normalize();

        velocity = userInput * duckMaxSpeed;

        rb2D.velocity = velocity;
    }
}
