using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public string[] lines;
    private DialogueSystem system;
    private Variables variables;
    void Start()
    {
        variables = GameObject.FindWithTag("Variables").GetComponent<Variables>();
        system = GameObject.FindWithTag("Dialogue").GetComponent<DialogueSystem>();
    }

    public void StartDialogue()
    {
        switch (variables.ForestStage)        
        {
            case 0:
                system.StartDialogue(variables.linesDict["HunterFirst"]);
                variables.ForestStage++;
                break;
            case 1:
                system.StartDialogue(variables.linesDict["HunterSecond"]);
                break;
        }
    }    
}
