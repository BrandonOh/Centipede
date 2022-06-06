using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_Bomb : MonoBehaviour
{
    private AS_PlayerController player;
    private AS_PlayerController blueEnemy;
    private AS_PlayerController redEnemy;
    private AS_PlayerController greenEnemy;
    private AS_ExplosionManager explosionManager;

    [SerializeField] private LayerMask unbreakableLayerMask;
    [SerializeField] private LayerMask breakableLayerMask;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<AS_PlayerController>();
        blueEnemy = GameObject.Find("BlueEnemy").GetComponent<AS_PlayerController>();
        redEnemy = GameObject.Find("RedEnemy").GetComponent<AS_PlayerController>();
        greenEnemy = GameObject.Find("GreenEnemy").GetComponent<AS_PlayerController>();
        explosionManager = GameObject.Find("ExplosionManager").GetComponent<AS_ExplosionManager>();

        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        //gameObject.GetComponent<NavMeshObstacle>().enabled = true;

        yield return new WaitForSeconds(3f);
        CallExplosion();
        StartCoroutine(CreateExplosions(Vector3.up));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.down));
        StartCoroutine(CreateExplosions(Vector3.left));

        if (player)
        {
            player.BombMinCapacity += 1;
        }
        if (blueEnemy)
        {
            blueEnemy.BombMinCapacity += 1;
        }
        if (redEnemy)
        {
            redEnemy.BombMinCapacity += 1;
        }
        if (greenEnemy)
        {
            greenEnemy.BombMinCapacity += 1;
        }
        Destroy(gameObject);
    }

    private void CallExplosion()
    {
        Instantiate(explosionManager.explosion, gameObject.transform.position, Quaternion.identity);
    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        int bombSize = player.BombFireSize + 1;
        bool explosionLimited = false;

        for (int i = 1; i < (bombSize); i++)
        {
            RaycastHit2D hitUnbreakableBlock = Physics2D.Raycast(transform.position, direction, i, unbreakableLayerMask);
            RaycastHit2D hitBreakableBlock = Physics2D.Raycast(transform.position, direction, i, breakableLayerMask);

            //Debug.Log("Direction: " + direction + ", i: " + i);
            if (hitUnbreakableBlock.collider == null)
            {
                if (explosionLimited == false)
                {
                    Instantiate(explosionManager.explosion, gameObject.transform.position + (i * direction), Quaternion.identity);
                }

                if (hitBreakableBlock.collider && explosionLimited == false)
                {
                    explosionLimited = true;
                    Debug.Log("Explosion hit a breakable block");
                }
            }

        }

        yield return new WaitForSeconds(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Explosion"))
        {
            Debug.Log("Chain explosion!");

            CallExplosion();
            StartCoroutine(CreateExplosions(Vector3.up));
            StartCoroutine(CreateExplosions(Vector3.right));
            StartCoroutine(CreateExplosions(Vector3.down));
            StartCoroutine(CreateExplosions(Vector3.left));

            if (player)
            {
                player.BombMinCapacity += 1;
            }
            if (blueEnemy)
            {
                blueEnemy.BombMinCapacity += 1;
            }
            if (redEnemy)
            {
                redEnemy.BombMinCapacity += 1;
            }
            if (greenEnemy)
            {
                greenEnemy.BombMinCapacity += 1;
            }
            Destroy(gameObject);
        }
    }

}
