using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTPTutorial : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(Variables.TPTutorialComplete);
    }
}
