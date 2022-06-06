using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    public int totalCoins;
    public Coin coin;
    private GameObject child;
    public Sprite emptyBrick;
    private Animator anim;
 

    private void Start()
    {

        child = transform.GetChild(0).gameObject;
       
        anim = GetComponent<Animator>();
    }

    void stopAnimation()
    {
        anim.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.bounds.max.y < transform.position.y
            && collision.collider.bounds.min.x < transform.position.x + .5f
            && collision.collider.bounds.max.x > transform.position.x -.5f
            && collision.collider.tag == "Player")
        {
            if (totalCoins > 0)
            {          
                anim.Play("Block_raise", 0, 0.25f);
                stopAnimation();
                anim.enabled = true;
                
                coin.addCoin();
                totalCoins -= 1;
                if (totalCoins == 0)
                {
                    child.GetComponent<SpriteRenderer>().sprite = emptyBrick;
                }
            }          
        }    
    }
}
