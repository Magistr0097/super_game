using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarterBlackMarketMan : MonoBehaviour, DialogueStarter
{
    public DialogueSystem system;
    private GameObject[] enemies;
    void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void StartDialogue()
    {
        foreach(var enemy in enemies)
            enemy.GetComponent<AINavigation>().Disable();
        switch (Variables.ForestStage)        
        {
            case 2:
                system.StartDialogue(Variables.linesDict["BlackManGoToHunter"]);
                break;
        }
    } 
}
