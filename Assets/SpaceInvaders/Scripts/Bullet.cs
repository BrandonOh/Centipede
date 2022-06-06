using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;


    //what happens when bullet collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {

            //instantiating hitEffect on collision
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity); //means no rotation

            //destroy effect with delay of 5 seconds
            Destroy(effect, 3.0f);

            //remove bullet on collision
            Destroy(gameObject);
        }
    }
}
