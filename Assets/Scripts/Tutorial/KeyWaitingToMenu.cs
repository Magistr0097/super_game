using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWaitingToMenu : MonoBehaviour
{
    public KeyCode keyCode;
    public SceneManager sceneManager;
    
    void Update()
    {
        if (!Input.GetKeyDown(keyCode)) return;
        sceneManager.ChangeScene(0);
    }
}
