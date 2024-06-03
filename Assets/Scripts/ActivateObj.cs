using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ActivateObj : MonoBehaviour
{
    public GameObject ObjToActivate;
    [FormerlySerializedAs("ObjToDisActivate")] public GameObject ObjToDisactivate;

    public void Activate()
    {
        ObjToDisactivate.SetActive(false);
        ObjToActivate.SetActive(true);
        ObjToActivate.GetComponent<LoadMenu>().GetSaves();
    }

    public void DisActivate()
    {
        ObjToActivate.SetActive(false);
        ObjToDisactivate.SetActive(true);
    }
}
