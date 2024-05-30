using UnityEngine;

public class KeyWaiting : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject tutorialVar;
    
    void Update()
    {
        if (!Input.GetKeyDown(keyCode)) return;
        gameObject.SetActive(false);
        tutorialVar.GetComponent<ActiveTutorialIfVariable>().KeyPushed();
    }
}
