using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

    public void Exit()
    {
        Debug.Log("EXIT!!!");
        Application.Quit();
    }
}
