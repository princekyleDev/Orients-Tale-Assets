using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalMainQuest : MonoBehaviour
{
    MonoliskMasterController MonoliskMaster;

    [Header("GameObject Quest UI")]
    public GameObject questUpdatedUI;

    // MainQuest
    [Header("Main Quest")]
    public GameObject FinalMainQuestStart;
    public GameObject FinalMainQuestComplete;

    [Header("Monolisks")]
    public int currentMonoliskCount;
    public int totalMonoliskCount;

    [SerializeField]
    private bool hasQuestUpdate;

    private void Start()
    {
        questUpdatedUI.SetActive(true);
        UpdateQuest();
    }

    public void UpdateQuest()
    {
        CheckQuest();
    }

    public void ReceiveQuest()
    {
        CheckQuest();
    }

    public void CheckQuest()
    {
        //Check Quest available

        if (FinalMainQuestStart == true)
        {
            PlayerQuests.MainQuest1Courtyard = true;

            // Start Side Quests
            FinalMainQuestStart.SetActive(true);
        }

        UpdateQuestUI();
    }

    public void MiniMonoliskDestroyed()
    {
        currentMonoliskCount += 1;
        Debug.Log("Count: " + currentMonoliskCount);
        if (currentMonoliskCount >= totalMonoliskCount)
        {

        }

    }

    public void UpdateMainQuest()
    {
        PlayerQuests.MainQuestCompletedCourtyard = true;
        UpdateQuest();
    }

    public void UpdateQuestUI()
    {
        if (hasQuestUpdate == true)
        {
            questUpdatedUI.SetActive(true);
        }
        hasQuestUpdate = false;
    }

}
