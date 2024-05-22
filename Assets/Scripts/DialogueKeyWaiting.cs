using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueKeyWaiting : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject dialogueSystem;
    private DialogueSystem script;
    // Start is called before the first frame update
    void Start()
    {
        script = dialogueSystem.GetComponent<DialogueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
            script.SkipText();
    }
}
