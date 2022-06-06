using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb2D;

    private void Start()
    {
  
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);        
    }



    void OnCollisionEnter2D(Collision2D collision)

    {
        string tag = collision.collider.tag;
        if (tag == "Block" || tag == "Player" || tag == "Pipe" || tag =="Goomba")
        {
            speed = -speed;
        }
    }
}
