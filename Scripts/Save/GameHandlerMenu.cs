using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandlerMenu : MonoBehaviour
{

    //public GameObject MasterVolume;
    //SetVolume SetMasterVolume;

    private void Awake()
    {
        LoadPlayerSettings();
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

        //LoadAllTimeRecord();
    }

    public void Save()
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
        // Debug.Log("Saved");
    }

    public void Load()
    {
        // What do I Load?
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/saveSettings.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/saveSettings.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            PlayerSettings.MasterVolume = saveObject.MasterVolumeValue;
            // test
            //Debug.Log(saveString);
        }
        else
        {
            return;
        }
    }

    public void LoadRawTimeRecord()
    {
        // What do I Load?
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/saveRawTimeRecord.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/saveRawTimeRecord.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            // Time Records
            SpeedrunAccounts.SavedRawTimer = saveObject.SavedRawTimer;
            //SpeedrunAccounts.FinishedRawTimer = saveObject.FinishedRawTimer;
            //SpeedrunAccounts.BestRawTimer = saveObject.BestRawTimer;

            Debug.Log(saveString);
        }
        else
        {
            return;
        }
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
            Debug.Log(saveString);
        }
        else
        {
            return;
        }
    }

    public void LoadAllTimeRecord()
    {
        // What do I Load?
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/saveTimeRecord.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/saveTimeRecord.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            // Time Records
            SpeedrunAccounts.SavedRawTimer = saveObject.SavedRawTimer;
            SpeedrunAccounts.FinishedRawTimer = saveObject.FinishedRawTimer;
            SpeedrunAccounts.BestRawTimer = saveObject.BestRawTimer;
            Debug.Log(saveString);
            Debug.Log("{GameHandlerMenu START} Loaded Time Records!");
        }
        else
        {
            return;
        }
    }

    public void NewRawTimeRecord()
    {
        SpeedrunAccounts.SavedRawTimer = 0;
    }

    public void LoadPlayerSettings()
    {
        // What do I Load?
        if (File.Exists(SaveSystem.SAVE_FOLDER + "/saveSettings.txt"))
        {
            string saveString = File.ReadAllText(SaveSystem.SAVE_FOLDER + "/saveSettings.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            PlayerSettings.MasterVolume = saveObject.MasterVolumeValue;
            // test
            Debug.Log(saveString);
        }
        else
        {
            return;
        }
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

    public void DeleteSaved()
    {
        // used when entering New Game

        if (File.Exists(SaveSystem.SAVE_FOLDER + "/save.txt"))
        {
            File.Delete(SaveSystem.SAVE_FOLDER + "/save.txt");

            PlayerAccount.maxHealth = 100;
            PlayerAccount.currentHealth = 100;
            PlayerAccount.maxStamina = 100;
            PlayerAccount.modifiedHealth = 0;
            PlayerAccount.modifiedStamina = 0;
            PlayerAccount.modifiedArmor = 0;
            PlayerAccount.modifiedDamage = 0;
            PlayerAccount.modifiedEvasion = 0;

            PlayerAccount.totalHealth = 0;
            PlayerAccount.totalStamina = 0;
            PlayerAccount.totalArmor = 0;
            PlayerAccount.totalDamage = 0;
            PlayerAccount.totalEvasion = 0;

            //Debug.Log("New game started");
            //Debug.Log("PlayerAccount.maxHealth" + PlayerAccount.maxHealth);
            //Debug.Log("PlayerAccount.currentHealth" + PlayerAccount.currentHealth);
            //Debug.Log(" PlayerAccount.maxStamina" + PlayerAccount.maxStamina);
        }
        else
        {
            return;
        }
    }

    public void DeleteTimeRecords()
    {
        // used when entering New Game

        if (File.Exists(SaveSystem.SAVE_FOLDER + "/saveTimeRecord.txt"))
        {
            File.Delete(SaveSystem.SAVE_FOLDER + "/saveTimeRecord.txt");

            SpeedrunAccounts.SavedRawTimer = 0;
            SpeedrunAccounts.FinishedRawTimer = 0;
            SpeedrunAccounts.BestRawTimer = 0;

            Debug.Log("{DeleteTimeRecords} Records Deleted");
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

    private class SaveObject
    {
        public int save_Scene;

        // Volumes
        public float MasterVolumeValue;

        // Time Records
        public float SavedRawTimer;
        public float FinishedRawTimer;
        public float BestRawTimer;

    }
}
