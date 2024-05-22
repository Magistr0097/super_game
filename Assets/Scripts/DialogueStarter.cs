using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public string[] lines;
    private DialogueSystem system;
    void Start()
    {
        system = GameObject.FindWithTag("Dialogue").GetComponent<DialogueSystem>();
    }

    public void StartDialogue()
    {
        system.StartDialogue(lines);
    }    
}
