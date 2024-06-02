using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum RespawnPositions
{
    Initial,
    OnEnterToForest,
    OnEnterToTown
}

public class Variables : MonoBehaviour
{
    public static bool IsFirstStartGame = true;
    public static bool MoveTutorialComplete = false;
    public static int ForestStage = 0;
    public static int TownStage = 0;
    public static int RoomStage = 0;
    public static Save LoadedSave = null;

    public static Dictionary<string, string[]> linesDict = new Dictionary<string, string[]>();
    public static readonly Dictionary<RespawnPositions, Vector3> RespawnPoints = new()
    {
        { RespawnPositions.Initial, new Vector3(6.43f, -25.4f)},
        { RespawnPositions.OnEnterToForest, new Vector3(-28.01f, 25.35f)},
        { RespawnPositions.OnEnterToTown, new Vector3(-45.32f, 7.09f)},
    };
}
