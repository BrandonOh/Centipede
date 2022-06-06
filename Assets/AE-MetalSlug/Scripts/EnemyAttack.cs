using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    public float speed = 3f;
    private Transform target;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    private float canAttack;


    private void OnTriggerEnter2D(Collider2D other)//when the player gets into the radius it will make him the target
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.transform;

            Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D other)// when the plaer leaves teh radius the target will be taken off.
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;

            Debug.Log(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        } 
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }

        }
    }

    void OnDrawGizmosSelected()// so we can see the range of the attack
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
