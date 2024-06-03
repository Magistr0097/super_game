using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarterHunter : MonoBehaviour, IDialogueStarter
{
    public GameObject TPTutorial;
    public GameObject TPTutorial2;
    public DialogueSystem system;
    public GameObject GameInput;
    public GameObject[] Portrets;
    private GameObject[] enemies;
    void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void StartDialogue()
    {   
        Portrets[0].SetActive(true);
        for (var i = 1; i < Portrets.Length; i++)
            Portrets[i].SetActive(false);
        foreach(var enemy in enemies)
            enemy.GetComponent<AINavigation>().Disable();
        switch (Variables.ForestStage)        
        {
            case 0:
                system.StartDialogue(Variables.linesDict["HunterFirst"]);
                Variables.ForestStage = 1;
                break;
            case 1:
                system.StartDialogue(Variables.linesDict["HunterSecond"]);
                break;
            case 2:
                system.StartDialogue(Variables.linesDict["HunterTutorial"]);
                Variables.TPTutorialComplete = true;
                TPTutorial.SetActive(true);
                TPTutorial2.SetActive(true);
                Variables.ForestStage = 3;
                break;
            case 3:
                system.StartDialogue(Variables.linesDict["HunterTutorialRepeat"]);
                break;
            case 4:
                system.StartDialogue(Variables.linesDict["HunterFirstQuestDone"]);
                Variables.ForestStage = 5;
                break;
            case 5:
                system.StartDialogue(Variables.linesDict["HunterGoToBlackMan"]);
                break;
            default:
                GameInput.SetActive(true);
                break;
        }
    }    
}
