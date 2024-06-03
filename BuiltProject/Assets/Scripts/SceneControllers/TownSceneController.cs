using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSceneController : MonoBehaviour
{
    public GameObject Enemies;
    public GameObject save;

    void Update()
    {
        if (Variables.TownStage < 1)
            Enemies.SetActive(false);
        else
            Enemies.SetActive(true);
    }
}
