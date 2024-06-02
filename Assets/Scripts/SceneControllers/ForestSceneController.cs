using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSceneController : MonoBehaviour
{
    public GameObject BlackMarketMan;
    public GameObject Enemies;

    void Update()
    {
        if (Variables.ForestStage <= 1)
            Enemies.SetActive(false);
        if (Variables.ForestStage >= 2)
            BlackMarketMan.SetActive(true);
    }
}
