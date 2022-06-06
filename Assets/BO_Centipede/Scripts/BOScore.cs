using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BOScore : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    public void AddPoints(int points)
    {
        score += points;
        txt.text = "Score: " + score.ToString();
    }
}
