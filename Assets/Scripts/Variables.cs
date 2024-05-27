using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public bool MoveTutorialComplete = false;
    public int ForestStage = 0;
    public Dictionary<string, string[]> linesDict = new Dictionary<string, string[]>();
    public Transform[] RespawnPoints =
    {
        
    };
}
