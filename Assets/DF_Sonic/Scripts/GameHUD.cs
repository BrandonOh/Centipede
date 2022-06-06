using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    public static GameHUD instance;

    public Text scoreText;
    public Text ringText;
    public Text livesText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerConreoller.score.ToString();
        ringText.text = "Rings: " + PlayerConreoller.ringCount.ToString();
        livesText.text = "Lives: " + PlayerConreoller.lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPointSlide()
    {
        PlayerConreoller.score += 5000;
        scoreText.text = "Score: " + PlayerConreoller.score.ToString();
    }

    public void AddPoint()
    {
        PlayerConreoller.score += 10000;
        scoreText.text = "Score: " + PlayerConreoller.score.ToString();
    }

    public void LoseaLife()
    {
        PlayerConreoller.lives -= 1;
        livesText.text = "Lives: " + PlayerConreoller.lives.ToString();
        PlayerConreoller.score = 0;
        scoreText.text = "Score: " + PlayerConreoller.score.ToString();
    }

    public void AddRings()
    {
        PlayerConreoller.ringCount++;
        PlayerConreoller.score += 100;
        ringText.text = "Rings: " + PlayerConreoller.ringCount.ToString();
        scoreText.text = "Score: " + PlayerConreoller.score.ToString();
    }

    public void LoseRings()
    {
        PlayerConreoller.ringCount = 0;
        ringText.text = "Rings: " + PlayerConreoller.ringCount.ToString();
    }
}
