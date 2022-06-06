using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_EnemyAI : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 3;

    private bool facingRight = false;
    private Rigidbody2D rb;
    private float moveDirection;
    private string clipName;
    private AnimatorClipInfo[] currentClipInfo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();

    }

    private void Animate()
    {
        

        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
            //animator.SetInteger("AnimState", 1);
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
            //animator.SetInteger("AnimState", 1);
        }
    }

    private void FixedUpdate()
    {//only moves if not spawning or dead
        if (!(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Skeleton_Rise")) &! animator.GetBool("isDead"))
        {
            {
                Move();
            }
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; //Inverse bool
        transform.Rotate(0f, 180f, 0f);
    }

    private void Move()
    {
        moveDirection = -1;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", rb.velocity.x);
    }
}
