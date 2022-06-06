using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public SceneLoader sceneLoader;

    public void AsteroidsButton()
    {
        sceneLoader.LoadSceneName("RoidsStartScreen");
    }
    public void FroggerButton()
    {
        sceneLoader.LoadSceneName("FroggerStartScreen");
    }
    public void TetrisButton()
    {
        sceneLoader.LoadSceneName("TetrisMenu");
    }
    public void CastleVaniaButton()
    {
        sceneLoader.LoadSceneName("CV_MainMenu");
    }
    public void BombermanButton()
    {
        sceneLoader.LoadSceneName("AS_GameMenu");
    }
}
