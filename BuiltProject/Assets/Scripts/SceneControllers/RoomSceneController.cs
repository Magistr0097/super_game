using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSceneController : MonoBehaviour
{
    public GameObject Boss;

    void Update()
    {
        if (Variables.RoomStage == 1)
            Boss.SetActive(true);
    }
}
