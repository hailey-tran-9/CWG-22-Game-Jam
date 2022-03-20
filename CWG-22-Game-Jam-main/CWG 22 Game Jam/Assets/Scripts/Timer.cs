using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currTime = 0;
    public float timeGoal = 100;
    public float IncBy = 1;
    bool timerIsRunning = true;
    public Text timeText;
    void Update()
    {
        if (currTime < timeGoal)
        {
            currTime += IncBy;
            DisplayTime(currTime);
        }
        else 
        {
            //endgame function
            timerIsRunning = false;
            currTime = 0;
        }
    }

    void DisplayTime(float currTime) {

        float minutes = Mathf.FloorToInt(currTime / 60); 
        float seconds = Mathf.FloorToInt(currTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
