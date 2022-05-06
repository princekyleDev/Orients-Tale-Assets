using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    GameHandlerMenu gameMenu;
    GameHandler gameHandler;

    [SerializeField]
    private float masterVolume;

    void Start()
    {
        //masterVolume = PlayerSettings.MasterVolume;
        //mixer.SetFloat("MusicVol", Mathf.Log10(masterVolume) * 20);

        //gameMenu = FindObjectOfType<GameHandlerMenu>();
        //gameHandler = FindObjectOfType<GameHandler>();
    }

    /*
    public void StartMasterSound()
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerSettings.MasterVolume) * 20);
    }
    */

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        masterVolume = sliderValue;
        PlayerSettings.MasterVolume = masterVolume;
        //Debug.Log("Player Settings: " + PlayerSettings.MasterVolume + "masterVolume: " + masterVolume);

        //if (gameMenu == null) { gameHandler.SaveSettings(); }
        //else { gameMenu.Save(); }
    }
}
