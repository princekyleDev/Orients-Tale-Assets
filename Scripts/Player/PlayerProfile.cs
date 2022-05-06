using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProfile : MonoBehaviour
{
    PlayerInventory playerInventoryProfile;
    PlayerGUIBar PlayerUI;
    GameHandler gameLoad;

    public bool isMainMenu;
    public bool isTutorial;
    private void Start()
    {
        playerInventoryProfile = FindObjectOfType<PlayerInventory>();
        gameLoad = FindObjectOfType<GameHandler>();

        if (isMainMenu == false && isTutorial == false)
        {
            playerInventoryProfile.buttonLoad();
            //playerInventoryProfile.buttonSave();
            gameLoad.Load();
            Debug.Log("{Player Profile} Player Profile Loaded");
        }

        if (isTutorial == true)
        {
            playerInventoryProfile.ClearItems();
            Debug.Log("{Player Profile} Cleared Items");
        }

        //Debug.Log("Awake Equipment Load and Saved!");
        //Debug.Log("Game Handler Load!");
        //Debug.Log(PlayerQuests.SideQuest1CompletedCourtyard);
    }

    // Button Trigger on Death Load Save Scene
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerUI.RevivePlayer();
    }

    public void ItemSave()
    {
        playerInventoryProfile.buttonSave();
        //Debug.Log("Trigger Equipment Load and Saved!");
    }

    public void ItemLoad()
    {
        playerInventoryProfile.buttonLoad();
        //Debug.Log("Items Loaded!");
    }

    public void NewGame()
    {
        // Health
        PlayerAccount.currentHealth = 100;
        PlayerAccount.totalHealth = 0;
        PlayerAccount.modifiedHealth = 0;

        // Stamina
        PlayerAccount.currentStamina = 100;
        PlayerAccount.modifiedStamina = 0;
        PlayerAccount.totalStamina = 0;

        // Stats
        PlayerAccount.totalArmor = 0;
        PlayerAccount.modifiedArmor = 0;
        PlayerAccount.totalDamage = 0;
        PlayerAccount.modifiedDamage = 0;
        PlayerAccount.totalEvasion = 0;
        PlayerAccount.modifiedEvasion = 0;
    }

    public void ClearQuest()
    {
        PlayerQuests.receivedQuestCourtyard = false;

        PlayerQuests.MainQuest1Courtyard = false;
        PlayerQuests.MainQuestProgress1Courtyard = false;
        PlayerQuests.MainQuestProgress2Courtyard = false;
        PlayerQuests.MainQuestCompletedCourtyard = false;

        PlayerQuests.SideQuest1StartCourtyard = false;
        PlayerQuests.SideQuest1CompletedCourtyard = false;

        PlayerQuests.SideQuest2StartCourtyard = false;
        PlayerQuests.SideQuest2CompletedCourtyard = false;
    }
}
