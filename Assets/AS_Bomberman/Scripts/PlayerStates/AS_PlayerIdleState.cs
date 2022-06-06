using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AS_PlayerIdleState : AS_PlayerBaseState
{
    public override void EnterState(AS_PlayerController player)
    {
        Debug.Log("Enter idling state...");
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
        Debug.Log("Player exited " + collision.gameObject.name);
    }

    public override void Update(AS_PlayerController player)
    {
        if (player.IsPlayerDead)
        {
            return;
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            player.TransitionToState(player.MovingState);
        }
        if (Input.GetButtonDown("Vertical"))
        {
            player.TransitionToState(player.MovingState);
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
