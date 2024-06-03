using UnityEngine;

public class AreaExitFromCastle : MonoBehaviour
{
    [SerializeField] private SceneManager sceneManager;
    [SerializeField] private int sceneIndexToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() && Variables.RoomStage == 1)
            sceneManager.ChangeScene(sceneIndexToLoad);
    }
}
