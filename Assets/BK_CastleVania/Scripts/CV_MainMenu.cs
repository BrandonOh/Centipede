using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CV_MainMenu : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("CV_Level1");
        }
    }
}
