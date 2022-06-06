using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisMenuController : MonoBehaviour
{
    public SceneLoader loader;

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("MenuSelect");
        loader.LoadSceneName("TetrisMain");
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("MenuSelect");
        loader.LoadMainMenu();
    }
}
