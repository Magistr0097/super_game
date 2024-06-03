using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaExitToCastle : MonoBehaviour
{
    [SerializeField] private SceneManager sceneManager;
    [SerializeField] private int sceneIndexToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() && Variables.TownStage < 1)
            sceneManager.ChangeScene(sceneIndexToLoad);
    }
}
