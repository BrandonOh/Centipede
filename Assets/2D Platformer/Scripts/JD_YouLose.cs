using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JD_YouLose : MonoBehaviour
{
    public bool GameHasEnded = false;
    public int EnemyHit = 0;
    

    public float restartDelay = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnemyHit++;
            GameOver();
        }
    }
    void GameOver()
    {
        if (GameHasEnded == false && EnemyHit >= 1)
        {
            GameHasEnded = true;
            Debug.Log("You Lose");
            Invoke("Restart", restartDelay);
            SceneManager.LoadScene(20);
        }
        
    }
}
