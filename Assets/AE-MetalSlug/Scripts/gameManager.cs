using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
   

    bool gameHasEnded = false;
  public void EndGame ()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            endGame();
            
        }
        
    }

    void endGame ()
    {
        SceneManager.LoadScene("End Scene");
    }
}
