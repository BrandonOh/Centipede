using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_EnemyAggressiveState : AS_PlayerBaseState
{
    int randomNumberSearch = 0;

    public override void EnterState(AS_PlayerController enemy)
    {
        Debug.Log("Entering aggressive state...");
        enemy.Target = null;
    }

    public override void OnCollisionEnter(AS_PlayerController enemy, Collision2D collision)
    {
        Debug.Log(enemy.name + " collided with " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("BreakableBlock") || collision.gameObject.CompareTag("Player"))
        {
            if (enemy.BombMinCapacity >= 1)
            {
                enemy.SpawnBomb();
                enemy.BombMinCapacity -= 1;
                enemy.IsBombSpawned = true;
                enemy.TransitionToState(enemy.DefensiveState);
            }
        }
    }

    public override void OnCollisionStay(AS_PlayerController enemy, Collision2D collision)
    {
        Debug.Log(enemy.name + " collided with " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("BreakableBlock") || collision.gameObject.CompareTag("Player"))
        {
            if (enemy.BombMinCapacity >= 1)
            {
                enemy.SpawnBomb();
                enemy.BombMinCapacity -= 1;
                enemy.IsBombSpawned = true;
                enemy.TransitionToState(enemy.DefensiveState);
            }
        }
    }

    public override void OnTriggerEnter(AS_PlayerController enemy, Collider2D collision)
    {
        //Detect breakable blocks
        if (collision.CompareTag("BreakableBlock") || collision.CompareTag("Player"))
        {
            if (enemy.BombMinCapacity >= 1)
            {
                enemy.SpawnBomb();
                enemy.BombMinCapacity -= 1;
                enemy.IsBombSpawned = true;
                enemy.TransitionToState(enemy.DefensiveState);
            }
        }
        if (collision.CompareTag("Bomb"))
        {
            enemy.TransitionToState(enemy.DefensiveState);
        }
    }

    public override void OnTriggerExit(AS_PlayerController enemy, Collider2D collision)
    {
        //Detect if the enemy player get out of range of breakable blocks
        if (collision.CompareTag("BreakableBlock"))
        {
            Debug.Log("Leaving block!");
        }
    }

    public override void Update(AS_PlayerController enemy)
    {
        randomNumberSearch = Random.Range(0, 1000);
        Debug.Log("NUMBER: >>>>>>>>  " + randomNumberSearch + "  <<<<<<<<<<<<");

        if (enemy.Target == null && randomNumberSearch >= 850)
        {
            enemy.Agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
        else if (enemy.Target != null)
        {
            enemy.Agent.SetDestination(enemy.Target.position);
        }
    }
}
