using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Player : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 400;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 6;
    public LayerMask enemyLayers;
    public LayerMask groundObjects;
    public float checkRadius;
    public Animator animator;


    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int currentAttack = 0;
    private float timeSinceAttack = 0.0f;
    //private float delayToIdle = 0.0f;

    //Awake is called after all objects are initialized. Called in a random order.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Increase timer that controls attack combo
        timeSinceAttack += Time.deltaTime;

        //Get Inputs
        ProcessInputs();

        //Animate
        Animate();
    }

    //Better for handling Physics. Can be called multiple times per update frame.
    private void FixedUpdate()
    {
        //Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            animator.SetBool("Grounded", isGrounded);
        }
        //Move
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            
        }
        isJumping = false;
    }

    private void Animate()
    {
        animator.SetFloat("AirSpeedY", rb.velocity.y);
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
            animator.SetInteger("AnimState", 1);
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
            animator.SetInteger("AnimState", 1);
        }
        else if (isJumping)
        {
            animator.SetTrigger("Jump");
        }
        else if (Input.GetMouseButtonDown(0) && timeSinceAttack > 0.25f)
        {
            Attack();
        }
        else if (Mathf.Abs(moveDirection) > Mathf.Epsilon && isGrounded)
        {
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); //Scale of -1 to 1.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight; //Inverse bool
        transform.Rotate(0f, 180f, 0f);
    }

    private void Attack()
    {
        currentAttack++;
        //Loop back to the first attack, after a 3-hit combo
        if (currentAttack > 3)
            currentAttack = 1;

        //Resets combo if too much time has passed
        if (timeSinceAttack > 1.0f)
            currentAttack = 1;

        //Attack animation
        animator.SetTrigger("Attack" + currentAttack);

        //Reset timer
        timeSinceAttack = 0.0f;

        //Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        //Apply damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<CV_Enemy>().TakeDamage(attackDamage);
        }
    }

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}
}
