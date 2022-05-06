using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ContinueBtnSwitch : MonoBehaviour
{
    public GameObject ContinueButton;
    //private Text BtnTextColor;

    // Start is called before the first frame update
    void Awake()
    {
        //BtnSwitch = GetComponent<Button>();
        //BtnTextColor = GetComponentInChildren<Text>();

        if (File.Exists(SaveSystem.SAVE_FOLDER + "/save.txt"))
        {
            ContinueButton.SetActive(true);
            /*
            BtnSwitch.interactable = true;
            BtnTextColor.color = new Color(
                BtnTextColor.color.r,
                BtnTextColor.color.g,
                BtnTextColor.color.b,
                1f);
            */
        }
        else
        {
            ContinueButton.SetActive(false);
            /*
            BtnSwitch.interactable = false;
            BtnTextColor.color = new Color(
                BtnTextColor.color.r,
                BtnTextColor.color.g,
                BtnTextColor.color.b,
                0.5f);
            */
        }
    }
}
