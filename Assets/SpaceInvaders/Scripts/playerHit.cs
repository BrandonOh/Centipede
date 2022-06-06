using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{
    public GameObject hitEffect;
    //public GameObject player;

    //private int lifeNum = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "alienBullet")
        {
            //instantiating hitEffect on collision
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity); //means no rotation

            //destroy effect with delay of 5 seconds
            Destroy(effect, 3.0f);

            //remove object on collision
            Destroy(gameObject);


            /*//testing: number of lives/new lives
            if (lifeNum == 1 || lifeNum == 2)
            {
                Destroy(GameObject.FindGameObjectWithTag($"extralife{lifeNum}")); //destroy extra life object
                Instantiate(player, transform.position, Quaternion.identity); //instantiate new object of player
                lifeNum+=1;
            }*/

        }
        else
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}