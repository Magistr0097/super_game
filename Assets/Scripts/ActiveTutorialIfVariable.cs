using UnityEngine;

public class ActiveTutorialIfVariable : MonoBehaviour
{
    private int keysCount;
    void Update()
    {
        if (Variables.MoveTutorialComplete)
            gameObject.SetActive(false);
    }

    public void KeyPushed()
    {
        keysCount++;
        if (keysCount > 3)
            Variables.MoveTutorialComplete = true;
    }
}
