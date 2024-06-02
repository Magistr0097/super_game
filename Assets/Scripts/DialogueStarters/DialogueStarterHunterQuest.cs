using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarterHunterQuest : MonoBehaviour, IDialogueStarter
{
    public GameObject GameInput;
    public GameObject Skin;
    public void StartDialogue()
    {
        Variables.ForestStage = 4;
        GameInput.SetActive(true);
        Skin.SetActive(false);
    } 
}
