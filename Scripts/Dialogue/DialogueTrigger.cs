using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string actorType = "";
    public bool questDialogue = false;
    public int activeSet = 0;
    public DialogueSet[] dialogueSets;
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(dialogueSets, messages, actors, actorType, questDialogue, activeSet);
    }
}

[System.Serializable]
public class DialogueSet
{
    public int startLine;
    public int endLine;
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor 
{
    public string name;
    public Sprite sprite;
}
