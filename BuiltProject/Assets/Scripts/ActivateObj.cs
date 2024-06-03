using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObj : MonoBehaviour
{
    public GameObject ObjToActivate;

    public void Activate()
    {
        ObjToActivate.SetActive(true);
        ObjToActivate.GetComponent<LoadMenu>().GetSaves();
    }

    public void DisActivate()
    {
        ObjToActivate.SetActive(false);
    }
}
