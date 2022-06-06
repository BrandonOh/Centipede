using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public CapsuleCollider2D stompPoint;
    private Transform parentObject;
    //public Animation anim;
    public Animator anim;
    public GoombaMovement goombaMovement;

    private void Start()
    {
        parentObject = gameObject.transform.parent;
        Debug.Log(parentObject);
    }

    private void DestroyObject()
    {
        Destroy(parentObject.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (gameObject.name == "Goomba")
        //{
            if (collision.collider.tag == "Player")
            {
                Destroy(stompPoint);
                anim.SetBool("isStomped", true);
                goombaMovement.speed = 0;
                Invoke("DestroyObject", .3f);
            }   
        //}  
    }
}
