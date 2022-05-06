using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishTime : MonoBehaviour
{
    public TextMeshProUGUI RecentTime;
    void Start()
    {
        float t1 = SpeedrunAccounts.FinishedRawTimer;

        string minutes = ((int)t1 / 60).ToString();
        string seconds = (t1 % 60).ToString("f2");
        RecentTime.text = minutes + ":" + seconds;

    }
}
