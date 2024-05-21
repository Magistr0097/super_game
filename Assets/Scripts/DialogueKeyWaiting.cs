using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogueKeyWaiting : MonoBehaviour
{
    public KeyCode keyCode;
    private DialogueSystem script;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindWithTag("Dialogue").GetComponent<DialogueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
            script.SkipText();
    }
}
