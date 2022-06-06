using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject GameMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameMenuUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameMenuUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void returnToMain()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("DF_MainMenu");
    }
}
