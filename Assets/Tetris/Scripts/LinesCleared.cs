using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LinesCleared : MonoBehaviour
{
    public static int LinesClear = 0;

    public Text lineText;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "TetrisMain")
        {
            LinesClear = 0;
        }
    }

    private void Update()
    {
        lineText.text = LinesClear.ToString();
    }
}
