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
    public GameObject nightmareSpawner;


    void Update()
    {
        if (currTime < timeGoal)
        {
            currTime += Time.deltaTime;
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
        if (seconds == 0) {
            if (minutes == 0) {
                return;
            }
            if (minutes == 1) {
                Checkpoint1();
            } else if (minutes == 2) {
                Checkpoint2();
            } else if (minutes == 3) {
                Checkpoint3();
            }
        }
    }

    //setting up checkpoints
    void Checkpoint1() {
        Debug.Log("passed checkpoint 1");
        DreamSpawner nightmareScript = nightmareSpawner.GetComponent<DreamSpawner>();
        nightmareScript.currWaveSize = 10;
        nightmareScript.spawnDelay =  1f;
    }

    void Checkpoint2() {
        Debug.Log("passed checkpoint 2");
        DreamSpawner nightmareScript = nightmareSpawner.GetComponent<DreamSpawner>();
        nightmareScript.currWaveSize = 20;
        nightmareScript.spawnDelay =  0.75f;
    }

    void Checkpoint3() {
        Debug.Log("passed checkpoint 3");
        DreamSpawner nightmareScript = nightmareSpawner.GetComponent<DreamSpawner>();
        nightmareScript.currWaveSize = 40;
        nightmareScript.spawnDelay =  0.5f;
    }
}
