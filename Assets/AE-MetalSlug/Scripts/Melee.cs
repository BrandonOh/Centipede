using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 25;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    void Attack()
    {
        //play an attack animation
        anim.SetTrigger("Attack");
        //Detect enemies in the range of the attack
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))// left click is attack
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
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
