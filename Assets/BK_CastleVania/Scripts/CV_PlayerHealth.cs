using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CV_PlayerHealth : MonoBehaviour
{
    public int maxHealth = 12;
    public int currentHealth;

    public CV_HealthBar healthBar;
    Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void AddHealth(int FHP)
    {
        currentHealth += FHP;
        healthBar.SetHealth(currentHealth);
    }

    public void SubtractHealth(int FHP)
    {
        currentHealth -= FHP;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Disable collider to prevent collision after dead.
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        //Die animation
        animator.SetTrigger("Death");
        //Disable the enemy after the animation is finished.
        StartCoroutine(waiter());
        IEnumerator waiter()
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
            SceneManager.LoadScene("CV_GameOver");
        }
    }


}
