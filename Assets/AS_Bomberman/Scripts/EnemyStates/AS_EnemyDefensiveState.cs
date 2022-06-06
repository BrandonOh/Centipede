using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AS_EnemyDefensiveState : AS_PlayerBaseState
{
    public override void EnterState(AS_PlayerController enemy)
    {
        Debug.Log("Entering defensive state...");
    }

    public override void OnCollisionEnter(AS_PlayerController enemy, Collision2D collision)
    {
        Debug.Log(enemy.name + " collided with " + collision.gameObject.name);
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    enemy.TransitionToState(enemy.AggressiveState);
        //}
    }

    public override void OnCollisionStay(AS_PlayerController enemy, Collision2D collision)
    {
        Debug.Log(enemy.name + " collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            //enemy.TransitionToState(enemy.AggressiveState);

        }
    }

    public override void OnTriggerEnter(AS_PlayerController enemy, Collider2D collision)
    {
        if (collision.CompareTag("BreakableBlock"))
        {
            enemy.TransitionToState(enemy.AggressiveState);
        }
        if (collision.CompareTag("Bomb"))
        {
            Debug.Log("RUNNNN!!!!");

            if (enemy.PositionTrigger == "Left")
            {
                enemy.Agent.SetDestination(enemy.transform.position + new Vector3(2f, 1f, 0));
            }
            if (enemy.PositionTrigger == "Right")
            {
                enemy.Agent.SetDestination(enemy.transform.position + new Vector3(-2f, -1f, 0));
            }
            if (enemy.PositionTrigger == "Up")
            {
                enemy.Agent.SetDestination(enemy.transform.position + new Vector3(-2f, -2f, 0));
            }
            if (enemy.PositionTrigger == "Down")
            {
                enemy.Agent.SetDestination(enemy.transform.position + new Vector3(-1f, 2f, 0));
            }
        }
    }

    public override void OnTriggerExit(AS_PlayerController enemy, Collider2D collision)
    {
        Debug.Log("Enemy is exiting " + collision.name);
    }

    public override void Update(AS_PlayerController enemy)
    {
        enemy.Target = GameObject.FindGameObjectWithTag("BreakableBlock").transform;

        if (enemy.IsBombSpawned)
        {
            if (enemy.PositionTrigger == "Left")
            {
                enemy.Agent.SetDestination(enemy.transform.position + new Vector3(2f, 1f, 0));
            }
            if (enemy.PositionTrigger == "Right")
            {
                enemy.Agent.SetDestination(enemy.transform.position + new Vector3(-2f, -1f, 0));
            }
            if (enemy.PositionTrigger == "Up")
            {
                enemy.Agent.SetDestination(enemy.transform.position + new Vector3(-2f, -2f, 0));
            }
            if (enemy.PositionTrigger == "Down")
            {
                enemy.Agent.SetDestination(enemy.transform.position + new Vector3(-1f, 2f, 0));
            }

            enemy.IsBombSpawned = false;
        }

        if (enemy.BombMinCapacity >= 1 && enemy.timePassed >= 5)
        {
            enemy.TransitionToState(enemy.AggressiveState);
        }
    }
}
