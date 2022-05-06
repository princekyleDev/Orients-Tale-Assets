using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject PlayerGameObject;
    [SerializeField] private GameObject SpeedRunTimerObject;
    [SerializeField] private GameObject PlayerOrbGameObject;

    //SetVolume SetMasterVolume;
    PlayerGUIBar PlayerUI;
    private PlayerController player;
    private SpeedrunTimer spdTimer;
    public bool LoadOnStart = false;

    private void Awake()
    {
        PlayerUI = FindObjectOfType<PlayerGUIBar>();
        player = PlayerGameObject.GetComponent<PlayerController>();
        spdTimer = SpeedRunTimerObject.GetComponent<SpeedrunTimer>();

        // Check if folder exist (if not, then create)
        if (!Directory.Exists(SaveSystem.SAVE_FOLDER))
        {
            Directory.CreateDirectory(SaveSystem.SAVE_FOLDER);
        }
        else
        {
            return;
        }

        if (LoadOnStart == true)
        {
            Load();
            //LoadTimeRecord();
            //LoadRawTimeRecord();
            //spdTimer.LoadRawTimer();
            //Debug.Log("{Game Handler} Load On Start");
        }
    }

    private void Start()
    {
        //SetMasterVolume = FindObjectOfType<SetVolume>();
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/save.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            if (saveObject.save_Scene == SceneManager.GetActiveScene().buildIndex)
            {
                Load();
                LoadTimeRecord();
                LoadRawTimeRecord();
                spdTimer.LoadRawTimer();
            }
            else
            {
                return;
            }

        }
        else
        {
            return;
        }

        //SetMasterVolume.StartMasterSound();
        //Debug.Log("Master Volume: " + PlayerSettings.MasterVolume);
    }

    public void SaveSettings()
    {
        // What do I Save?
        SaveObject saveObject = new SaveObject
        {
            //save_Scene = SceneManager.GetActiveScene().buildIndex,
            MasterVolumeValue = PlayerSettings.MasterVolume

        };
        string json = JsonUtility.ToJson(saveObject);

        // Save the Data
        File.WriteAllText(SaveSystem.SAVE_FOLDER + "/saveSettings.txt", json);
    }

    public void SaveRunTimeRecord()
    {
        // What do I Save?
        SaveObject saveObject = new SaveObject
        {
            SavedRawTimer = SpeedrunAccounts.SavedRawTimer,

        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log("{SaveRunTimeRecord} SavedRawTimer = " + SpeedrunAccounts.SavedRawTimer);
        // Save the Data
        File.WriteAllText(SaveSystem.SAVE_FOLDER + "/saveRawTimeRecord.txt", json);
    }

    public void SaveTimeRecord()
    {
        // What do I Save?
        SaveObject saveObject = new SaveObject
        {
            //SavedRawTimer = SpeedrunAccounts.SavedRawTimer,
            FinishedRawTimer = SpeedrunAccounts.FinishedRawTimer,
            BestRawTimer = SpeedrunAccounts.BestRawTimer,
        };
        string json = JsonUtility.ToJson(saveObject);

        // Save the Data
        File.WriteAllText(SaveSystem.SAVE_FOLDER + "/saveTimeRecord.txt", json);
    }

    public void LoadTimeRecord()
    {
        // What do I Load?
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/saveTimeRecord.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/saveTimeRecord.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            // Time Records
            //SpeedrunAccounts.SavedRawTimer = saveObject.SavedRawTimer;
            SpeedrunAccounts.FinishedRawTimer = saveObject.FinishedRawTimer;
            SpeedrunAccounts.BestRawTimer = saveObject.BestRawTimer;
        }
        else
        {
            return;
        }
    }

    public void LoadRawTimeRecord()
    {
        // What do I Load?
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/SaveRunTimeRecord.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/SaveRunTimeRecord.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            // Time Records
            SpeedrunAccounts.SavedRawTimer = saveObject.SavedRawTimer;
        }
        else
        {
            return;
        }
    }

    public void DeleteTimeRecord()
    {
        // used when entering New Game
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/saveTimeRecord.txt"))
        {
            File.Delete(SaveSystem.SAVE_FOLDER + "/saveTimeRecord.txt");

            SpeedrunAccounts.FinishedRawTimer = 0;
            SpeedrunAccounts.BestRawTimer = 0;

            Debug.Log("Cleared Time Records");
        }
        else
        {
            return;
        }

        if (File.Exists(SaveSystem.SAVE_FOLDER + "/saveRawTimeRecord.txt"))
        {
            File.Delete(SaveSystem.SAVE_FOLDER + "/saveRawTimeRecord.txt");

            SpeedrunAccounts.SavedRawTimer = 0;
            SpeedrunAccounts.BestRawTimer = 0;

            Debug.Log("{DeleteTimeRecords} Cleared Raw Time Records");
        }
        else
        {
            return;
        }
    }

    public void Save()
    {
        // What do I Save?
        SaveObject saveObject = new SaveObject
        {
            player_Position = player.transform.position,
            player_Orb_Position = PlayerOrbGameObject.transform.position,
            save_Scene = SceneManager.GetActiveScene().buildIndex,

            totalHealth = PlayerAccount.totalHealth,
            modifiedHealth = PlayerAccount.modifiedHealth,
            totalStamina = PlayerAccount.totalStamina,
            modifiedStamina = PlayerAccount.modifiedStamina,
            totalArmor = PlayerAccount.totalArmor,
            modifiedArmor = PlayerAccount.modifiedArmor,
            totalDamage = PlayerAccount.totalDamage,
            modifiedDamage = PlayerAccount.modifiedDamage,
            totalEvasion = PlayerAccount.totalEvasion,
            modifiedEvasion = PlayerAccount.modifiedEvasion,

            // Courtyard Quests
            receivedQuestCourtyard = PlayerQuests.receivedQuestCourtyard,

            MainQuest1 = PlayerQuests.MainQuest1Courtyard,
            MainQuestProgress1Courtyard = PlayerQuests.MainQuestProgress1Courtyard,
            MainQuestProgress2Courtyard = PlayerQuests.MainQuestProgress2Courtyard,
            MainQuestCompletedCourtyard = PlayerQuests.MainQuestCompletedCourtyard,

            SideQuest1Start = PlayerQuests.SideQuest1StartCourtyard,
            SideQuest1Completed = PlayerQuests.SideQuest1CompletedCourtyard,

            SideQuest2Start = PlayerQuests.SideQuest2StartCourtyard,
            SideQuest2Completed = PlayerQuests.SideQuest2CompletedCourtyard,

            // Courtyard Items
            hasBakunawa1SZ = PlayerQuests.hasBakunawa1SZ,

            /*
            player_Health = player.currentHealth,
            Hp_1 = Heart1.activeSelf,
            Hp_2 = Heart2.activeSelf,
            Hp_3 = Heart3.activeSelf,
            Hp_4 = Heart4.activeSelf,
            Hp_5 = Heart5.activeSelf,
            */
        };

        string json = JsonUtility.ToJson(saveObject);

        Debug.Log("{Game Handler} Data Saved Successfully");
        // Save the Data
        File.WriteAllText(SaveSystem.SAVE_FOLDER + "/save.txt", json);
    }

    public void LoadScene()
    {
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/save.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            int loadSavedScene = saveObject.save_Scene;

            SceneManager.LoadScene(loadSavedScene);
        }
        else
        {
            return;
        }
    }

    public void GameOverLoadScene()
    {
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/save.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            int loadSavedScene = saveObject.save_Scene;

            SceneManager.LoadScene(loadSavedScene);
        }
        else
        {
            return;
        }

        PlayerUI.RevivePlayer();
    }

    public void Load()
    {
        // What do I Load?
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/save.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            //MasterVolumeValue = PlayerSettings.MasterVolume;

            // Load Player Data
            player.transform.position = new Vector3(
                saveObject.player_Position.x,
                saveObject.player_Position.y,
                saveObject.player_Position.z);

            PlayerOrbGameObject.transform.position = new Vector3(
                saveObject.player_Orb_Position.x,
                saveObject.player_Orb_Position.y,
                saveObject.player_Orb_Position.z);

            // Player Stats
            PlayerAccount.totalHealth = saveObject.totalHealth;
            PlayerAccount.modifiedHealth = saveObject.modifiedHealth;
            PlayerAccount.totalStamina = saveObject.totalStamina;
            PlayerAccount.modifiedStamina = saveObject.modifiedStamina;
            PlayerAccount.totalArmor = saveObject.totalArmor;
            PlayerAccount.modifiedArmor= saveObject.modifiedArmor;
            PlayerAccount.totalDamage = saveObject.totalDamage;
            PlayerAccount.modifiedDamage = saveObject.modifiedDamage;
            PlayerAccount.totalEvasion = saveObject.totalEvasion;
            PlayerAccount.modifiedEvasion = saveObject.modifiedEvasion;

            // Courtyard Quests
            PlayerQuests.receivedQuestCourtyard = saveObject.receivedQuestCourtyard;

            PlayerQuests.MainQuest1Courtyard = saveObject.MainQuest1;
            PlayerQuests.MainQuestProgress1Courtyard = saveObject.MainQuestProgress1Courtyard;
            PlayerQuests.MainQuestProgress2Courtyard = saveObject.MainQuestProgress2Courtyard;
            PlayerQuests.MainQuestCompletedCourtyard = saveObject.MainQuestCompletedCourtyard;

            PlayerQuests.SideQuest1StartCourtyard = saveObject.SideQuest1Start;
            PlayerQuests.SideQuest1CompletedCourtyard = saveObject.SideQuest1Completed;

            PlayerQuests.SideQuest2StartCourtyard = saveObject.SideQuest2Start;
            PlayerQuests.SideQuest2CompletedCourtyard = saveObject.SideQuest2Completed;

            // Courtyard Items
            PlayerQuests.hasBakunawa1SZ = saveObject.hasBakunawa1SZ;

            // test
            Debug.Log(saveString);
            Debug.Log("{Game Handler} Data Loaded Successfully");
        }
        else
        {
            return;
        }
    }

    public void DeleteSaved()
    {
        // used when entering New Game
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/save.txt"))
        {
            File.Delete(SaveSystem.SAVE_FOLDER + "/save.txt");

            Debug.Log("{Game Handler}New game started");
        }
        else
        {
            return;
        }
    }

    private class SaveObject
    {
        public Vector3 player_Position;
        public Vector3 player_Orb_Position;
        public int save_Scene;

        public float MasterVolumeValue;

        // Player Stats 
        public int totalHealth;
        public int modifiedHealth;
        public int totalStamina;
        public int modifiedStamina;
        public int totalArmor;
        public int modifiedArmor;
        public int totalDamage;
        public int modifiedDamage;
        public int totalEvasion;
        public int modifiedEvasion;

        // Courtyard Quest
        public bool receivedQuestCourtyard;

        public bool MainQuest1;
        public bool MainQuestProgress1Courtyard;
        public bool MainQuestProgress2Courtyard;
        public bool MainQuestCompletedCourtyard;

        public bool SideQuest1Start;
        public bool SideQuest1Completed;

        public bool SideQuest2Start;
        public bool SideQuest2Completed;

        // Time Records
        public float SavedRawTimer;
        public float FinishedRawTimer;
        public float BestRawTimer;

        // Items
        public bool hasBakunawa1SZ;

        /*
        public int player_Health;
        public bool Hp_1;
        public bool Hp_2;
        public bool Hp_3;
        public bool Hp_4;
        public bool Hp_5;
        */
    }
}
