using UnityEngine;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private SceneManager sceneManager;
    [SerializeField] private int sceneIndexToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
            sceneManager.ChangeScene(sceneIndexToLoad);
    }
}
