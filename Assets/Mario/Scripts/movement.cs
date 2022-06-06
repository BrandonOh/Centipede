using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rb2d;
    float horizontalMove = 0f;
    public float moveSpeed = 40f; 
    bool jump = false;
    public Animator anim;
    public float stompBounce = 5f;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.collider.name == "StompPoint")
        { 
            Debug.Log("Stomp");
            //rb2d.AddForce(collision.contacts[0].normal * stompBounce);
            rb2d.AddForce(Vector3.up * stompBounce);
        }
    }
}
