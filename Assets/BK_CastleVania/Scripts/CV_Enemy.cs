using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CV_Enemy : MonoBehaviour
{
    //public CV_EnemyAI CV_EnemyAI;
    public Animator animator;
    public int maxHealth = 6;
    public int currentHealth;

    


    private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation

        if(currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            //Decrease count of current enemies
            CV_EnemySpawn.enemyCount--;
            //Add Score
            CV_Score.score += 10;
            if (CV_Score.score >= 100)
            {
                SceneManager.LoadScene("CV_GameOver");
            }
            //Disable collider to prevent collision with dead enemies.
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            //Die animation
            animator.SetBool("isDead", true);
            //Disable the enemy after the animation is finished.
            StartCoroutine(waiter());
            IEnumerator waiter()
            {
                yield return new WaitForSeconds(1);
                Destroy(gameObject);
            }
        }
    }
}
