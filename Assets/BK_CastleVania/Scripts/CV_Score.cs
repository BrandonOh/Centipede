using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CV_Score : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI text;
    public string scoreDisplay;

    

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay = "YOUR SCORE: \n" + score;
        text.text = scoreDisplay;
    }
}
