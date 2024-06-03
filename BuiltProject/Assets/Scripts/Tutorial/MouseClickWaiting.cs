using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickWaiting : MonoBehaviour
{
    public GameObject NextStage;
    
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
            gameObject.SetActive(false);
            NextStage.SetActive(true);
    }
}
