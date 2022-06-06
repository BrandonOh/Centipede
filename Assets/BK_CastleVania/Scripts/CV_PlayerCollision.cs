
using UnityEngine;

public class CV_PlayerCollision : MonoBehaviour
{
    public int collisionDamage = 2;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("We hit an enemy.");


            //Apply damage
            GetComponent<CV_PlayerHealth>().SubtractHealth(collisionDamage);

            //Animate player
        }
    }
}
