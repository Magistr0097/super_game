using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public GameObject End;
    public GameObject Dialogue;

    // Update is called once per frame
    void Update()
    {
        if (Variables.TownStage == 123 && Dialogue.activeSelf == false)
        {
            End.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
