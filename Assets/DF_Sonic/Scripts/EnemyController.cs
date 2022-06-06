using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float speed = 5;
    [SerializeField] bool ShouldMove;

    public Rigidbody2D rb;
    public LayerMask groundLayer;
    RaycastHit2D hit;

    public Transform groundCheck;

    bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, groundLayer);
    }

    private void FixedUpdate()
    {
        if(ShouldMove == true)
        {
            if (hit.collider != false)
            {

                if (isFacingRight)
                {

                    rb.velocity = new Vector2(speed, rb.velocity.y);

                }
                else
                {

                    rb.velocity = new Vector2(-speed, rb.velocity.y);

                }

            }
            else
            {

                isFacingRight = !isFacingRight;

                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
        } 
    }
}
