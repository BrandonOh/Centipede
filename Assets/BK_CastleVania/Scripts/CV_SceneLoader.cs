using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CV_SceneLoader : MonoBehaviour
{

    //public int currentLevel = 0;

    public void LoadNextLevel()
    {

        SceneManager.LoadScene("CV_Level1");
        CV_Score.score = 0;
    }


    public static void CV_MainMenu()
    {
        SceneManager.LoadScene("CV_MainMenu");
    }

    public void GameOver()
    {
        SceneManager.LoadScene(24);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}