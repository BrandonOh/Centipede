using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float jumpPower;// so jumps dont feel too floaty and can control them better
    [SerializeField] private LayerMask groundLayer;
    public Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    
    

    private void Awake() //awake is called when the instance is being loaded
    {
        //Grab reference for rigidbody and animator from the player
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();//this will check the player object for the component rigidbody2d, it will then take it and put it on the body variable, getcomponent are used for references.
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // to make it easier and not code the whole thing in the future
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip player when moving left/right
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))// Players Jump
        {
            jump();

            //Adjustable jump height
            if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
                body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        }

        //Set animator paramaters
        anim.SetBool("Run", horizontalInput != 0);// if you are not standing still the run animation will play
        anim.SetBool("Grounded", isGrounded());

        if(body.position.y < 17f)
        {
            FindObjectOfType<gameManager>().EndGame();
        }

    }

    private void jump() // Jumping code
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
    }

    private bool isGrounded()// sees if player is grounded
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }


    }
