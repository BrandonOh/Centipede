using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOMainMenu : MonoBehaviour
{
    public void ButtonClicked(string level)
    {
        SceneManager.LoadScene(level);
    }
}
