using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFPS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        //Debug.Log("receivedQuestCourtyard: " + PlayerQuests.receivedQuestCourtyard);
        //Debug.Log("MainQuest1Courtyard: " + PlayerQuests.MainQuest1Courtyard);
        //Debug.Log("MainQuestProgress1Courtyard: " + PlayerQuests.MainQuestProgress1Courtyard);
        //Debug.Log("SideQuest1StartCourtyard: " + PlayerQuests.SideQuest1StartCourtyard);
        //Debug.Log("SideQuest1CompletedCourtyard: " + PlayerQuests.SideQuest1CompletedCourtyard);
    }
}
