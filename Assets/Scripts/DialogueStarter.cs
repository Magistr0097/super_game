using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public string[] lines;
    private DialogueSystem system;
    // private Variables variables;
    void Start()
    {
        // variables = GameObject.FindWithTag("Variables").GetComponent<Variables>();
        system = GameObject.FindWithTag("Dialogue").GetComponent<DialogueSystem>();
    }

    public void StartDialogue()
    {
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
