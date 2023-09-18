using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb2D;
    public float duckMaxSpeed = 3.5f;
    public float acceleration = 11;
    public float deacceleration = 7;

    Vector2 userInput;
    Vector2 velocity;
    Vector2 duckPosition;

    // Start is called before the first frame update
    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        velocity = userInput * duckMaxSpeed;

        userInput.x = Input.GetAxisRaw("Horizontal");
        userInput.y = Input.GetAxisRaw("Vertical");

        //velocity += userInput * acceleration;

        //if( velocity.sqrMagnitude > duckMaxSpeed * duckMaxSpeed) { velocity.Normalize(); velocity *= duckMaxSpeed; }

        //if (userInput.sqrMagnitude == 0) { velocity *= 2f - deacceleration; }

        //duckPosition += rb2D.velocity;

        rb2D.velocity = velocity;
    }
}
