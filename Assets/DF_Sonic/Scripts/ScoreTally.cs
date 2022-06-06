using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTally : MonoBehaviour
{

    public Text scoreText;
    public Text ringText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerConreoller.score.ToString();
        ringText.text = "Rings: " + PlayerConreoller.ringCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
