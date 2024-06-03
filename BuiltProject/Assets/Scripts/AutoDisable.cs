using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    private float timeToDisable = 0f;

    void Update()
    {
        if (gameObject.activeSelf && timeToDisable <= 0)
            timeToDisable = 1.5f;
        if (timeToDisable > 0)
            timeToDisable -= Time.deltaTime;
        if (timeToDisable <= 0)
            gameObject.SetActive(false);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
        timeToDisable = 0f;
    }
}
