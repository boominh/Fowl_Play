using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{

    Rigidbody2D rb2D;
    public float duckMaxSpeed = 4f;
    public float acceleration = 15;
    public float deacceleration = 6;

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

        userInput.x = Input.GetAxisRaw("Horizontal");
        userInput.y = Input.GetAxisRaw("Vertical");

        
           
        if (userInput.sqrMagnitude > duckMaxSpeed ) {userInput.Normalize();}
      

        velocity += userInput * acceleration;

        if( velocity.sqrMagnitude > duckMaxSpeed * duckMaxSpeed) { velocity.Normalize(); velocity *= duckMaxSpeed; }

        if (velocity.sqrMagnitude == 0) { velocity *= 0.9f - deacceleration; }

        duckPosition += velocity;

        rb2D.velocity = velocity;




    }
}
