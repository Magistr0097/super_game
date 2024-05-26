using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTutorialIfVariable : MonoBehaviour
{
    private int keysCount = 0;
    private GameObject variables;
    void Start()
    {
        variables = GameObject.FindWithTag("Variables");
        if (variables.GetComponent<Variables>().MoveTutorialComplete)
            gameObject.SetActive(false);
    }

    public void KeyPushed()
    {
        keysCount++;
        if (keysCount > 3)
        {
            variables.GetComponent<Variables>().MoveTutorialComplete = true;
        }
    }
}
