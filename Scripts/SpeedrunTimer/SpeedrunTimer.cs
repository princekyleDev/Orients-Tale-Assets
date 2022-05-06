using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
    public GameObject TimerObject;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI RawTimerText;
    public bool timerActive;
    public bool isContinuation;

    GameHandler gHandler;

    //Records
    public float FinishTime;
    public float BestTime;

    [SerializeField]private float t;
    //[SerializeField]private float startTime;
    public bool pauseTime;

    // Start is called before the first frame update
    void Start()
    {
        gHandler = FindObjectOfType<GameHandler>();
        timerActive = SpeedrunAccounts.ActiveTimerUI;

        if(timerActive == true)
        {
            TimerObject.SetActive(true);
        }
        else
        {
            TimerObject.SetActive(false);
        }

        if (isContinuation)
        {
            LoadRawTimer();
        }

        //startTime = Time.time;
    }

    void Update()
    {
        if(pauseTime == false)
        {
            //t = Time.time - startTime;
            t += Time.deltaTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            TimerText.text = minutes + ":" + seconds;
            RawTimerText.text = (t).ToString("f2");
        }
    }

    public void timerOnUI()
    {
        SpeedrunAccounts.ActiveTimerUI = true;
        TimerObject.SetActive(true);
    }

    public void timerOffUI()
    {
        SpeedrunAccounts.ActiveTimerUI = false;
        TimerObject.SetActive(false);
    }

    public void SaveRawTimer()
    {
        SpeedrunAccounts.SavedRawTimer = t;
        Debug.Log("{SaveRawTimer} Got Timer " + SpeedrunAccounts.SavedRawTimer);
        PauseTimer();
    }

    public void PauseTimer()
    {
        pauseTime = true;
    }

    public void ResumeTimer()
    {
        pauseTime = false;
    }

    public void LoadRawTimer()
    {
        t = SpeedrunAccounts.SavedRawTimer;
        Debug.Log("{LoadRawTimer} Got Timer " + SpeedrunAccounts.SavedRawTimer);
        ResumeTimer();
    }

    public void FinishTimer()
    {
        PauseTimer();
        // Save Time here
        SpeedrunAccounts.SavedRawTimer = t;
        FinishTime = t;

        GetBestRecord();
    }

    public void GetBestRecord()
    {
        BestTime = SpeedrunAccounts.BestRawTimer;
        if (BestTime == 0)
        {
            // First Time Record
            SpeedrunAccounts.BestRawTimer = FinishTime;
            SpeedrunAccounts.FinishedRawTimer = FinishTime;
        }
        else if (FinishTime < BestTime)
        {
            // New Record
            SpeedrunAccounts.BestRawTimer = FinishTime;
            SpeedrunAccounts.FinishedRawTimer = FinishTime;
        }
        else 
        {
            SpeedrunAccounts.FinishedRawTimer = FinishTime;
        }
        gHandler.SaveTimeRecord();
        Debug.Log("Finish Time: " + FinishTime);
        Debug.Log("Best Time: " + BestTime);

    }

}
