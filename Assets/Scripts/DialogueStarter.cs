using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    private DialogueSystem system;
    private GameObject[] enemies;
    // private Variables variables;
    void Start()
    {
        // variables = GameObject.FindWithTag("Variables").GetComponent<Variables>();
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
                system.StartDialogue(Variables.linesDict["HunterSecond"]);
                Variables.ForestStage++;
                break;
            case 1:
                system.StartDialogue(Variables.linesDict["HunterSecond"]);
                break;
        }
    }    
}
