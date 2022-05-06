using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TMP_Text actorName;
    public TMP_Text messageText;
    public RectTransform backgroundBox;
    public GameObject UIButtons;

    // Audio
    public AudioSource dialogueFx;
    public AudioSource voiceDialogueFx;

    // Audio Fx
    public AudioClip nextMessageFx;

    //Voices
    public AudioClip dunganFx;
    public AudioClip duwendeFx;
    public AudioClip kapreFx;
    public AudioClip devGhostFx;

    // Typewriter
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    Message[] currentMessages;
    Actor[] currentActors;

    // Dialogue set
    DialogueSet[] currentDialogueSet;
    private int currentStartLine;
    private int currentEndLine;
    private int currentSet = 0;
    public bool isQuestDialogue = false;

    string currentActorType;
    int activeMessage = 0;
    public bool isWriting = false;
    public bool voiceActive = true;
    public bool isActive = false;


    public void OpenDialogue(DialogueSet[] dialogueSets, Message[] messages, Actor[] actors, string actorType, bool questDialogue, int activeSet)
    {
        currentSet = activeSet;
        currentMessages = messages;
        currentActors = actors;
        currentActorType = actorType;
        activeMessage = 0;
        isActive = true;

        if (questDialogue == true)
        {
            // Dialogue set
            isQuestDialogue = questDialogue;
            currentDialogueSet = dialogueSets;
            DialogueSet set = currentDialogueSet[currentSet];
            currentStartLine = set.startLine;
            currentEndLine = set.endLine;

            UIButtons.SetActive(false);
            StartCoroutine(DisplayQuestMessage());
            backgroundBox.LeanScale(Vector3.one, 0.2f).setEaseInOutExpo();
        }
        else
        {
            UIButtons.SetActive(false);
            StartCoroutine(DisplayMessage());
            backgroundBox.LeanScale(Vector3.one, 0.2f).setEaseInOutExpo();
        }

        /*
        Debug.Log("Started conversation! StartLine: " + set.startLine);
        Debug.Log("Started conversation! StartLine: " + set.endLine);
        Debug.Log("Started conversation! Loaded Dialogue Sets: " + dialogueSets.Length);
        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        Debug.Log("isQuestDialogue:" + questDialogue);
        */
    }

    IEnumerator DisplayMessage() 
    {
        Message messageToDisplay = currentMessages[activeMessage];
        //messageText.text = messageToDisplay.message;
        fullText = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        isWriting = true;
        //Debug.Log("isWriting: " + isWriting);
        voiceActive = true;
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            messageText.text = currentText;
            if (voiceActive == true)
            {
                PlayVoice();
            }
            yield return new WaitForSeconds(delay);
        }
        isWriting = false;
        //Debug.Log("isWriting: " + isWriting);

        AnimateTextColor();
    }

    IEnumerator DisplayQuestMessage()
    {
        /*
        Debug.Log("Got CurrentSet: " + currentSet);
        Debug.Log("Got StartLine: " + currentStartLine);
        Debug.Log("Got EndLine: " + currentEndLine);
        */

        Message messageToDisplay = currentMessages[currentStartLine];
        //messageText.text = messageToDisplay.message;
        fullText = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        isWriting = true;
        voiceActive = true;
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            messageText.text = currentText;
            if (voiceActive == true)
            {
                PlayVoice();
            }
            yield return new WaitForSeconds(delay);
        }
        isWriting = false;
        //Debug.Log("isWriting: " + isWriting);

        AnimateTextColor();
    }

    private void PlayVoice()
    {
        switch (currentActorType)
        {
            case "Dungan":
                voiceDialogueFx.PlayOneShot(dunganFx);
                break;

            case "Duwende":
                voiceDialogueFx.PlayOneShot(duwendeFx);
                break;

            case "Kapre":
                voiceDialogueFx.PlayOneShot(kapreFx);
                break;

            case "DevGhost":
                voiceDialogueFx.PlayOneShot(devGhostFx);
                break;

            default:
                print("Dialogue Manager: Missing actor type.");
                break;
        }
    }

    public void ButtonNextMessage()
    {
        dialogueFx.PlayOneShot(nextMessageFx);

        if (isWriting == true)
        {
            delay = 0.0f;
            voiceActive = false;
        }
        else if (isWriting == false)
        {
            delay = .1f;
            if (isQuestDialogue == false)
            {
                // Normal Dialogue
                NextMessage();
            }
            else
            {
                NextMessageQuest();
            }
        }
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            StartCoroutine(DisplayMessage());
            // DisplayMessage();
        }
        else 
        {
            ExitDialogue();
        }
    }

    public void NextMessageQuest()
    {
        //Debug.Log("currentStartLine: " + currentStartLine);

        currentStartLine++;
        if (currentStartLine < currentEndLine + 1)
        {
            StartCoroutine(DisplayQuestMessage());
        }
        else
        {
            ExitDialogue();
        }
    }

    public void NextDialogueSet()
    {
        currentSet++;
    }

    void AnimateTextColor() 
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    void Start() 
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    public void ExitDialogue()
    {
        UIButtons.SetActive(true);
        backgroundBox.LeanScale(Vector3.zero, 0.2f).setEaseInOutExpo();
        isActive = false;
        voiceActive = false;
        isWriting = false;
    }

}
