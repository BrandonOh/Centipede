using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_BombUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AS_PlayerController player = collision.GetComponent<AS_PlayerController>();
            player.BombMaxCapacity += 1;
            player.BombMinCapacity += 1;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            AS_PlayerController enemy = collision.GetComponent<AS_PlayerController>();
            enemy.BombMaxCapacity += 1;
            enemy.BombMinCapacity += 1;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}
