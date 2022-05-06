using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainQuest : MonoBehaviour
{
    [Header("GameObject Quest UI")]
    public GameObject questUpdatedUI;

    // MainQuest
    [Header("Main Quest")]
    public GameObject MainQuestStart;
    public GameObject MainQuestProgress1;
    public GameObject MainQuestProgress2;
    public GameObject MainQuestProgress2UnlockableGate;
    public GameObject MainQuestsFinishedUI;
    public GameObject MainQuestCompletedUnlockableGate;

    // SideQuest
    [Header("Side Quest")]
    // Slaying Side Quest
    [Header("Slaying Quest")]
    public GameObject SideQuest1;
    public GameObject SideQuest1Start;
    public TMP_Text SideQuest1Text;
    public GameObject SideQuest1Complete;
    // Finding Side Quest
    [Header("Finding Quest")]
    public GameObject SideQuest2;
    public GameObject SideQuest2Start;
    public GameObject SideQuest2Complete;

    // SlayQuest
    [Header("Slay Quest Objectives")]
    public int neededToSlay = 5;
    private int currentCountSlay = 0;

    // Finding Side Quest
    //[Header("Slay Quest Objectives")]
    //public int neededToSlay = 5;
    //public int currentCountSlay;

    [SerializeField]
    private bool hasQuestUpdate;
    [SerializeField]
    private bool ReceivedQuest;

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
        ReceivedQuest = true;
        PlayerQuests.receivedQuestCourtyard = ReceivedQuest;
        CheckQuest();
    }

    public void CheckQuest()
    {
        //Check Quest available

        if (PlayerQuests.receivedQuestCourtyard == true)
        {
            PlayerQuests.MainQuest1Courtyard = true;
            
            // Start Side Quests
            SideQuest1.SetActive(true);
            SideQuest2.SetActive(true);

            // Main Quest
            if (PlayerQuests.MainQuest1Courtyard == true)
            {
                // Disable On Start Quest
                MainQuestStart.SetActive(false);

                //Started Main Quest Progress 1
                PlayerQuests.MainQuestProgress1Courtyard = true;

            }
            
            if (PlayerQuests.MainQuestProgress1Courtyard == true) 
            {
                MainQuestStart.SetActive(false);
                // Enable New Main Quest
                //Started Main Quest Progress 2
                // Set in quest trigger
                //PlayerQuests.MainQuestProgress1Courtyard = true;
                MainQuestProgress1.SetActive(true);
            }

            if (PlayerQuests.MainQuestProgress2Courtyard == true)
            {
                // Disable Previous Main Quest
                MainQuestStart.SetActive(false);
                MainQuestProgress1.SetActive(false);

                // Enable New Main Quest
                //Started Main Quest Progress 2
                // Set in quest trigger
                MainQuestProgress2UnlockableGate.SetActive(false);
                MainQuestProgress2.SetActive(true);

            }

            if (PlayerQuests.MainQuestCompletedCourtyard == true)
            {
                // Disable Prevois Main Quest
                MainQuestStart.SetActive(false);
                MainQuestProgress1.SetActive(false);
                MainQuestProgress2.SetActive(false);

                // Enable New Main Quest
                //Started Main QuestComplete UI
                // Set in quest trigger
                //PlayerQuests.MainQuestCompletedCourtyard = true;
                MainQuestCompletedUnlockableGate.SetActive(false);
                MainQuestsFinishedUI.SetActive(true);
            }

            // Slaying Side Quest
            if (PlayerQuests.SideQuest1CompletedCourtyard == false)
            {
                //if SideQuest1Start is NOT Complete
                PlayerQuests.SideQuest1StartCourtyard = true;
                SideQuest1Start.SetActive(true);
            }
            else
            {
                //if SideQuest1Start is Complete
                SideQuest1Start.SetActive(false);

                // Set by a quest trigger
                //PlayerQuests.SideQuest1CompletedCourtyard = true;
                SideQuest1Complete.SetActive(true);
            }

            // Get Quest
            if (PlayerQuests.SideQuest2CompletedCourtyard == false)
            {
                //if SideQuest1Start is NOT Complete
                PlayerQuests.SideQuest2StartCourtyard = true;
                SideQuest2Start.SetActive(true);
            }
            else
            {
                //if SideQuest21Start is Complete
                SideQuest2Start.SetActive(false);

                // Set by a quest trigger
                //PlayerQuests.SideQuest2CompletedCourtyard = true;
                SideQuest2Complete.SetActive(true);
            }

            hasQuestUpdate = true;
        }
         UpdateQuestUI();
    }

    public void UpdateSlayQuest()
    {
        currentCountSlay += 1;
        SideQuest1Text.text = ("Slay " + currentCountSlay + "/" + "5 Slimes.");
        Debug.Log("Count: " + currentCountSlay);
        if (currentCountSlay >= neededToSlay)
        {
            PlayerQuests.SideQuest1CompletedCourtyard = true;
            UpdateQuest();
            UnlockMainQuest();
        }

    }

    public void UpdateFindQuest()
    {
        PlayerQuests.SideQuest2CompletedCourtyard = true;
        UpdateQuest();
        Debug.Log("SideQuest2CompletedCourtyardt: " + PlayerQuests.SideQuest2CompletedCourtyard);
        UnlockMainQuest();
    }

    public void UnlockMainQuest()
    {
        if (PlayerQuests.SideQuest1CompletedCourtyard == true && PlayerQuests.SideQuest2CompletedCourtyard == true)
        {
            PlayerQuests.MainQuestProgress2Courtyard = true;
            UpdateQuest();
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
