using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestEventGathering : MonoBehaviour
{
    public DialogueTrigger QuestDialogueTrigger;
    public GameObject questIndicator;

    [Header("GameObject Quest UI")]
    public GameObject questUpdatedUI;
    public GameObject questStartUI;
    public GameObject questProgressUI;
    public TMP_Text questProgressUITooltip;
    public GameObject questFinishedUI;

    [Header("GameObject Quest Items")]
    public GameObject questSpawnGameObjReq;

    [Header("GameObject Quest Info")]
    public string questName = "Quest Name";
    public string questReq = "Soul Fragments";
    public int questQuantityReq = 4;
    public int currentQuantityReq = 0;

    [Header("GameObject Quest Unlockables")]
    public GameObject portal;

    [Header("GameObject Quest Status")]
    public bool startQuestEvent = false;
    public bool FinishQuestEvent = false;
    public bool CompletedQuestEvent = false;

    // Quest update fire only once
    private bool hasFiredOnce = false;
    private bool hasFiredOnce2 = false;

    public void Update()
    {
        if (startQuestEvent == true)
        {
            if (hasFiredOnce == false)
            {
                FireOnlyOnce();
            }
            StartQuest();
        }

        if (currentQuantityReq >= 4)
        {
            FinishQuestEvent = true;
            if (CompletedQuestEvent == false) 
            {
                if (FinishQuestEvent == true)
                {
                    FinishQuest();
                }
            }
        }
        else
        {

            questProgressUITooltip.text = "Gather " + currentQuantityReq +"/" + questQuantityReq + " " + questReq;
        }

        if (FinishQuestEvent == true)
        {
            if (hasFiredOnce2 == false)
            {
                FireOnlyOnce2();
            }
            questIndicator.SetActive(false);
            questProgressUI.SetActive(false);
            questFinishedUI.SetActive(true);

            // GameObject Unlockables
            portal.SetActive(true);
        }

    }

    public void FireOnlyOnce()
    {
        questUpdatedUI.SetActive(true);
        hasFiredOnce = true;
    }

    public void FireOnlyOnce2()
    {
        questUpdatedUI.SetActive(true);
        hasFiredOnce2 = true;
    }

    public void StartQuest()
    {
        questStartUI.SetActive(false);
        questProgressUI.SetActive(true);
        questSpawnGameObjReq.SetActive(true);
    }

    public void FinishQuest()
    {
        QuestDialogueTrigger.activeSet++;
        CompletedQuestEvent = true;
    }

    public void GotItem()
    {
        currentQuantityReq += 1;
    }
}
