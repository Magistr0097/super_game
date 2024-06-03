using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarterMa : MonoBehaviour, IDialogueStarter
{
    [SerializeField] private GameObject gameInput;
    [SerializeField] private GameObject Gashish;
    
    public void StartDialogue()
    {
        Variables.ForestStage = 7;
        gameInput.SetActive(true);
        Gashish.SetActive(false);
    }
}
