using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSceneController : MonoBehaviour
{
    public GameObject Enemies;

    void Update()
    {
        if (Variables.TownStage < 1)
            Enemies.SetActive(false);
    }
}
