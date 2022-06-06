using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AS_PlayerMovingState : AS_PlayerBaseState
{
    public Vector2 movement;

    public override void EnterState(AS_PlayerController player)
    {
        Debug.Log("Enter moving state...");
    }

    public override void OnCollisionEnter(AS_PlayerController player, Collision2D collision)
    {
        Debug.Log("Player collided with " + collision.gameObject.name);
    }

    public override void OnCollisionStay(AS_PlayerController player, Collision2D collision)
    {
        Debug.Log("Player is colliding with " + collision.gameObject.name);
    }

    public override void OnTriggerEnter(AS_PlayerController player, Collider2D collision)
    {
        if (collision.CompareTag("Explosion"))
        {
            Debug.Log("Player was hit by explosion");

            //If player get hit by an explosion, then the player is dead
            player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            player.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            player.IsPlayerDead = true;
            SceneManager.LoadScene("AS_ScreenLose");

        }
    }

    public override void OnTriggerExit(AS_PlayerController player, Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(AS_PlayerController player)
    {
        if (player.IsPlayerDead)
        {
            return;
        }

        Debug.Log("moving...");
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x == 0 && movement.y == 0)
        {
            player.TransitionToState(player.IdleState);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (player.BombMinCapacity >= 1)
            {
                player.SpawnBomb();
                player.BombMinCapacity -= 1;
            }
        }
    }
}
