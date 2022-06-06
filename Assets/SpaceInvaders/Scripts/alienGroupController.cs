using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienGroupController : MonoBehaviour
{
    public float speed = 20.0f;
    bool moveLeft = false; //boolean for switching direction

    // Update is called once per frame
    void Update()
    {
        //setting min and max bounds of screen
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)); //minbound
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)); //maxbound

        //setting initial position and clamping - doesnt go out of the boundaries
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 173, maxScreenBounds.x - 150), transform.position.y, 0);

        //conditional statement for automatic movement of alien group
        if (transform.position.y > 30) //for as long as the group is above a certain point - stop moving when this point is reached
        {
            //as long as x position is not equal to the left boundary and moveLeft is true = translate group to the left
            if (moveLeft && transform.position.x != minScreenBounds.x + 173)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            //if position value is equal to left boundary value and moveLeft is true - move group down by 20 and set moveLeft to false
            else if (moveLeft && transform.position.x == minScreenBounds.x + 173)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 20);
                moveLeft = false;
            }
            //as long as x position is not equal to the right boundary and moveLeft is false = translate group to the right
            else if (!moveLeft && transform.position.x != maxScreenBounds.x - 150)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            //if position value is equal to right boundary value and moveLeft is false - move group down by 20 and set moveLeft to true
            else if (!moveLeft && transform.position.x == maxScreenBounds.x - 150)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 20);
                moveLeft = true;
            }
        }
        
    }
}