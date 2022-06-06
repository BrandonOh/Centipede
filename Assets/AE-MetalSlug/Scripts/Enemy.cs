using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    //ENEMY HEALTH
    //public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Play hurt animation
        // animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

        if (tag == "Enemy")
        {
            if(currentHealth > maxHealth)
        {
                currentHealth = maxHealth;
            }
        else if (currentHealth <= 0)
            {

                currentHealth = 0;
                Debug.Log("Boss Died");
                SceneManager.LoadScene("End Scene");


            }
        }
    }
       void Die()
    {

        Debug.Log("Enemy died!");

        //Die anim
        //animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;// so we dont run into him after he dies

        //Disable the enemy
        this.enabled = false;
        
    }

    

}
