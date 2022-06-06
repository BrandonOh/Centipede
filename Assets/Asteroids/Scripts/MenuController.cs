using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public SceneLoader loader;

    public void LoadNextLevel()
    {
        loader.LoadNextLevel();
    }

    public void RestartGame()
    {
        loader.LoadNextLevel(-1);
    }

    public void MainMenu()
    {
        loader.LoadMainMenu();
    }

}
