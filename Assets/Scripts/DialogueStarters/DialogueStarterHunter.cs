using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarterHunter : MonoBehaviour, DialogueStarter
{
    private DialogueSystem system;
    private GameObject[] enemies;
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        system = GameObject.FindWithTag("Dialogue").GetComponent<DialogueSystem>();
    }

    public void StartDialogue()
    {
        foreach(var enemy in enemies)
            enemy.GetComponent<AINavigation>().Disable();
        switch (Variables.ForestStage)        
        {
            case 0:
                system.StartDialogue(Variables.linesDict["HunterFirst"]);
                Variables.ForestStage++;
                break;
            case 1:
                system.StartDialogue(Variables.linesDict["HunterSecond"]);
                break;
        }
    }    
}
