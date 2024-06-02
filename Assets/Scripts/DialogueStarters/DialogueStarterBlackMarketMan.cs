using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarterBlackMarketMan : MonoBehaviour, IDialogueStarter
{
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
            case 2:
                system.StartDialogue(Variables.linesDict["BlackManGoToHunter"]);
                break;
            case 5:
                system.StartDialogue(Variables.linesDict["BlackManFirstQuest"]);
                Variables.ForestStage = 6;
                break;
            case 6:
                system.StartDialogue(Variables.linesDict["BlackManFirstQuestRepeat"]);
                break;
            case 7:
                system.StartDialogue(Variables.linesDict[""]);
                break;
            default:
                GameInput.SetActive(true);
                break;
        }
    } 
}
