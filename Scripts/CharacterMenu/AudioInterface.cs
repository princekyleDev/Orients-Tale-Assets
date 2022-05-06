using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInterface : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField]
    public AudioSource interfaceFx;

    [Header("Audio Fx")]
    [SerializeField]
    public AudioClip MenuButtons;
    public AudioClip DropDown;
    public AudioClip DropUp;
    public AudioClip Alert;
    public AudioClip AlertLight;
    public AudioClip Error;

    public void MenuButtonSound()
    {
        interfaceFx.PlayOneShot(MenuButtons);
    }

    public void AlertSound()
    {
        interfaceFx.PlayOneShot(Alert);
    }

    public void AlertLightSound()
    {
        interfaceFx.PlayOneShot(Alert);
    }

    public void ErrorSound()
    {
        interfaceFx.PlayOneShot(Error);
    }

    public void DropDownSound()
    {
        interfaceFx.PlayOneShot(DropDown);
    }

    public void DropUpSound()
    {
        interfaceFx.PlayOneShot(DropUp);
    }
}
