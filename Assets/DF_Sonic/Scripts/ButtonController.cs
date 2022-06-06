using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void toMainMenu()
    {
        Debug.Log("To main");
        SceneManager.LoadScene("DF_MainMenu");
    }
    public void toMainGame()
    {
        Debug.Log("Playing game");
        SceneManager.LoadScene("DF_MainGame");
    }

    public void exit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
