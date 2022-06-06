using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    public Color buttonColor;
    public Color hoverColor;
    public Color clickedColor;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = clickedColor;
        FindObjectOfType<MainMenu>().LoadNewGame();
    }
    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = hoverColor;
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = buttonColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.bounds.max.y < transform.position.y
            && collision.collider.bounds.min.x < transform.position.x + .5f
            && collision.collider.bounds.max.x > transform.position.x - .5f
            && collision.collider.tag == "Player")
        {
            anim.Play("Block_Hit", 0, 0.4f);
            FindObjectOfType<M_AudioManager>().Play("Bump");
            FindObjectOfType<MainMenu>().LoadNewGame();
        }
    }
}
