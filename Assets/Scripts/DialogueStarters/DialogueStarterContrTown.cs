using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarterContrTown : MonoBehaviour, IDialogueStarter
{
    public DialogueSystem system;
    public GameObject GameInput;
    //public GameObject[] Portrets;
    private GameObject[] enemies;
    void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void StartDialogue()
    {
        // Portrets[0].SetActive(true);
        // for (var i = 1; i < Portrets.Length; i++)
        //     Portrets[i].SetActive(false);
        foreach(var enemy in enemies)
            enemy.GetComponent<AINavigation>().Disable();
        switch (Variables.ForestStage)        
        {
            case 8:
                system.StartDialogue(Variables.linesDict["BlueManQuest"]);
                break;
            default:
                GameInput.SetActive(true);
                break;
        }
    } 
}
