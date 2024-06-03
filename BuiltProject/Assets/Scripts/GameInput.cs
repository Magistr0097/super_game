using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Vector2 GetPlayerMovementVector2()
    {
        Vector2 directionMovement = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            directionMovement.y = 1;
        if (Input.GetKey(KeyCode.S))
            directionMovement.y = -1;
        if (Input.GetKey(KeyCode.A))
            directionMovement.x = -1;
        if (Input.GetKey(KeyCode.D))
            directionMovement.x = 1;
        
        return directionMovement.normalized;
    }
}
