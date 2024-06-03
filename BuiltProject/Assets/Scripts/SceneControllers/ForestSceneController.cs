using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSceneController : MonoBehaviour
{
    public GameObject BlackMarketMan;
    public GameObject FirstHunterQuest;
    public GameObject MainEntrance;
    public GameObject Enemies;

    void Update()
    {
        if (Variables.ForestStage <= 1)
            Enemies.SetActive(false);
        else
            Enemies.SetActive(true);
        if (Variables.ForestStage >= 2)
        {
            BlackMarketMan.SetActive(true);
            MainEntrance.SetActive(false);
        }
        if (Variables.ForestStage == 3)
            FirstHunterQuest.SetActive(true);
    }
}
