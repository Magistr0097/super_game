using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarterDarkPact : MonoBehaviour, DialogueStarter
{
    public DialogueSystem system;
    public GameObject GameInput;
    private GameObject[] enemies;
    void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void StartDialogue()
    {
        foreach(var enemy in enemies)
            enemy.GetComponent<AINavigation>().Disable();
        switch (Variables.RoomStage)        
        {
            case 0:
                system.StartDialogue(Variables.linesDict["DarkPactFound"]);
                Variables.RoomStage = 1;
                Variables.TownStage = 1;
                Variables.ForestStage = 2;
                break;
            case 1:
                system.StartDialogue(Variables.linesDict["DarkPactNoTime"]);
                break;
            default:
                GameInput.SetActive(true);
                break;
        }
    } 
}
