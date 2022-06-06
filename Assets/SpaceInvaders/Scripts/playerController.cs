using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float playerSpeed = 150.0f; //speed variable - accessible from inspector (public)

    public Rigidbody2D rb; //referencing rigidBody - it will be the one that will move around the player

    Vector2 movement; //variable to access in fixed update


    // Update is called once per frame
    void Update() //getting input for the movements - where movement is triggered
    {

        movement.x = Input.GetAxisRaw("Horizontal"); //storing horizontal axis value

       //setting min and max bounds of screen
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); //minbound
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)); //maxbound

        //setting initial position and clamping - doesnt go out of the boundaries
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x +1, maxScreenBounds.x -1), transform.position.y, 0);

    }

    //for actually moving player based on inputs
    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime); //access rigidbody component and use function movePosition to move object.
    }
}