using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AS_Time : MonoBehaviour
{
    [SerializeField] private float timeLeft = 60f;
    private Text timeText;
    private float minutes;
    private float seconds;

    private void Start()
    {
        timeText = GetComponent<Text>();
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTime(timeLeft);
        }
        else
        {
            timeLeft = 0;
            Debug.Log("Time's up, you lose!");
            SceneManager.LoadScene("AS_ScreenLose");
        }
    }

    private void UpdateTime(float currentTime)
    {
        currentTime += 1;

        minutes = Mathf.FloorToInt(currentTime / 60);
        seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }
}
