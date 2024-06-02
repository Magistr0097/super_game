using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum RespawnPositions
{
    Initial,
    OnEnterToForest,
    OnEnterToTown,
    OnEnterToTownBeginning,
    OnExitFromRoom
}

public class Variables : MonoBehaviour
{
    public static bool IsFirstStartGame = true;
    public static bool MoveTutorialComplete = false;
    public static bool TPTutorialComplete = false;
    public static int ForestStage = 0;
    public static int TownStage = 0;
    public static int RoomStage = 0;
    public static Save LoadedSave = null;

    public static Dictionary<string, string[]> linesDict = new();
    public static readonly Dictionary<RespawnPositions, Vector3> RespawnPoints = new()
    {
        { RespawnPositions.Initial, new Vector3(6.43f, -25.4f)},
        { RespawnPositions.OnEnterToForest, new Vector3(-28.01f, 25.35f)},
        { RespawnPositions.OnEnterToTown, new Vector3(-45.32f, 7.09f)},
        { RespawnPositions.OnEnterToTownBeginning, new Vector3(67.06f, 9.71f)},
        { RespawnPositions.OnExitFromRoom, new Vector3(17.21f, -19.19f)},
    };
}
