using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarterHunter : MonoBehaviour, DialogueStarter
{
    public GameObject TPTutorial;
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
                break;
        }
    }    
}
