using UnityEngine;

public class KeyWaiting : MonoBehaviour
{
    public KeyCode keyCode;
    public ActiveTutorialIfVariable tutorialVar;
    
    void Update()
    {
        if (!Input.GetKeyDown(keyCode)) return;
        gameObject.SetActive(false);
        tutorialVar.KeyPushed();
    }
}
