using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConreoller : MonoBehaviour
{
    //Components
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;
    public LayerMask whatIsGround;
    public BoxCollider2D regularColli;
    public GameObject jumpHitBox;
    public GameObject slideHitBox;

    //Values
    public static int ringCount;
    public static int score;
    public static int lives = 3;

    //Movement Values
    public float speed = 10;
    public float jumpVelocity;

    //bools
    public static bool isGrounded;
    bool canTakeDamage = true;
    bool isRunning;
    bool isSliding;
    bool canMove = true;
    bool canSlide = true;

    //Other
    float collisionRadius = 0.5f;
    public Vector2 bottomOffset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, whatIsGround);
        Run();
        jump();
        
    }


    void Run()
    {
        
        if (canMove)
        {
            float x = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0) { isRunning = true; anim.SetBool("isRunning", true); }
            else { isRunning = false; anim.SetBool("isRunning", false); }
            if (Input.GetAxisRaw("Horizontal") < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (Input.GetAxisRaw("Horizontal") > 0) transform.rotation = Quaternion.identity;
        }

        if (canSlide && isRunning && isGrounded && Input.GetKeyDown(KeyCode.C))
        {
            canSlide = false;
            canMove = false;
            isSliding = true;
            anim.SetBool("isSlide", true);
            regularColli.enabled = false;
            sr.enabled = false;
            slideHitBox.SetActive(true);
            StartCoroutine("stopSlide");
        }

        if(isSliding && !isGrounded)
        {
            isSliding = false;
            StartCoroutine("earlyStopSlide");
        }
    }

    void jump()
    {
        if (isGrounded && !isSliding)
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("inAir", true);
                rb.velocity = Vector2.up * jumpVelocity;
                StartCoroutine("earlyStopSlide");
            }
            anim.SetBool("inAir", false);
            regularColli.enabled = true;
            jumpHitBox.SetActive(false);
        } 
        else if (!isGrounded && !isSliding)
        {
            anim.SetBool("inAir", true);
            regularColli.enabled = false;
            jumpHitBox.SetActive(true);
        }
    }

    void TakeDamage()
    {
        if(ringCount > 0 && canTakeDamage)
        {
            GameHUD.instance.LoseRings();
            StartCoroutine("takeDamage");
        }
        else if (ringCount == 0 && canTakeDamage)
        {
            GameHUD.instance.LoseaLife();
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ring"))
        {
            Destroy(collision.gameObject);
            GameHUD.instance.AddRings();
        }

        if(collision.gameObject.CompareTag("Goal"))
        {
            //Win();
            StartCoroutine("PerformWin");
        }
    }
    private void OnCollisionEnter2D(Collision2D collidedobject)
    {
        if(collidedobject.gameObject.tag == "NoTouch")
        {
            ringCount = 0;
            Die();
        }
        //For Springs
        if(collidedobject.gameObject.layer == 16)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            rb.velocity = Vector2.up * 45f;
        }

        if(isGrounded && !isSliding)
        {
            if(collidedobject.gameObject.layer == 15)
            {
                TakeDamage();
            }
        }


        if(!isGrounded)
        {
            if (collidedobject.gameObject.layer == 15)
            {
                Destroy(collidedobject.gameObject);
                GameHUD.instance.AddPoint();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0f;
                rb.velocity = Vector2.up * 25f;
            }
        }

        if(isSliding)
        {
            if (collidedobject.gameObject.layer == 15)
            {
                Destroy(collidedobject.gameObject);
                GameHUD.instance.AddPointSlide();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0f;
                rb.velocity = Vector2.up * 20f;
                StartCoroutine("earlyStopSlide");
            }
        }
    }

    void Die()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
        anim.Play("DF_Death");
        StartCoroutine("LoseLife");
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
    }


    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.8f);
        anim.Play("DF_Idle");
        anim.SetBool("isSlide", false);
        regularColli.enabled = true;
        sr.enabled = true;
        canMove = true;
        isSliding = false;
        slideHitBox.SetActive(false);
        yield return new WaitForSeconds(1);
        canSlide = true;
    }

    IEnumerator earlyStopSlide()
    {
        yield return new WaitForSeconds(0f);
        anim.Play("DF_Idle");
        anim.SetBool("isSlide", false);
        regularColli.enabled = true;
        sr.enabled = true;
        canMove = true;
        isSliding = false;
        slideHitBox.SetActive(false);
        yield return new WaitForSeconds(1);
        canSlide = true;
    }

    IEnumerator takeDamage()
    {
        canTakeDamage = false;
        canMove = false;
        rb.velocity = Vector3.zero;
        anim.Play("DF_Damaged");
        yield return new WaitForSeconds(.4f);
        anim.Play("DF_Idle");
        canMove = true;
        canTakeDamage = true;
    }

    IEnumerator LoseLife()
    {
        yield return new WaitForSeconds(.8f);
        if (lives >= 0)
        {
            SceneManager.LoadScene("DF_MainGame");
        }
        else if (lives < 0)
        {
            SceneManager.LoadScene("DF_MainMenu");
        }
    }

    IEnumerator PerformWin()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.velocity = Vector2.right * 9.5f;
        yield return new WaitForSeconds(1f);
        anim.Play("DF_winAnimation");
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("DF_ResultScene");
    }
}
