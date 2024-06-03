using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaised : MonoBehaviour
{
    public GameObject TutorialToOff;
    
    void Update()
    {
        if (!Input.GetMouseButtonUp(0)) return;
            gameObject.SetActive(false);
            TutorialToOff.SetActive(false);
            Variables.TPTutorialComplete = true;
    }
}
