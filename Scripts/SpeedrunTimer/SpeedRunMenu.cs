using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedRunMenu : MonoBehaviour
{
    public TextMeshProUGUI BestTime;
    public TextMeshProUGUI RecentTime;

    void Start()
    {
        float t1 = SpeedrunAccounts.BestRawTimer;
        float t2 = SpeedrunAccounts.FinishedRawTimer;

        string minutes = ((int)t1 / 60).ToString();
        string seconds = (t1 % 60).ToString("f2");
        BestTime.text = minutes + ":" + seconds;

        string minutes2 = ((int)t2 / 60).ToString();
        string seconds2 = (t2 % 60).ToString("f2");
        RecentTime.text = minutes + ":" + seconds;

    }
}
