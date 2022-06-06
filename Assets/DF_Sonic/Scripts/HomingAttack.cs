using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingAttack : MonoBehaviour
{
    private Rigidbody2D rb;

    bool canAttack = true;

    public float attackSpeed;

    GameObject markedEnemy;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerConreoller.isGrounded == false)
        {
            targetEnemy();
            if (Input.GetKeyDown(KeyCode.X) && canAttack)
            {
                if(markedEnemy != null)
                {
                    var direction = (markedEnemy.transform.position - transform.position).normalized;
                    rb.AddForce(direction * attackSpeed);
                    canAttack = false;
                    StartCoroutine("homingAttackCooldown");
                } else if (markedEnemy == null)
                {
                    return;
                }

            }
        }
    }
    public void targetEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Attackable");
        GameObject target = null;
        Vector3 currentPosition = transform.position;
        Vector3 difference;

        float distance = 75f;
        float magnitude;

        foreach (GameObject enemy in enemies)
        {
            difference = enemy.transform.position - currentPosition;
            magnitude = difference.sqrMagnitude;
            if(magnitude < distance)
            {
                target = enemy;
                distance = magnitude;
            }
        }

        if (target != null)
        {
            if(markedEnemy == null || (markedEnemy.GetInstanceID() != target.GetInstanceID()))
            {
                markedEnemy = target;
            }
        }
    }

    IEnumerator homingAttackCooldown()
    {
        yield return new WaitForSeconds(.2f);
        canAttack = true;
    }
}
