using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public static PlayerMovement Instance { get; private set; }
    
    public bool isRightRunning { get; private set; }
    public bool isLeftRunning { get; private set; }
    public bool isForwardRunning { get; private set; }
    public bool isBackwardRunning { get; private set; }
    
    public GameObject gameOver; //find way to delete it
    private readonly float minMovementSpeed = 0.1f;
    private const float Speed = 5f;
    private Rigidbody2D rb;
    
    
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var moveVector = GameInput.Instance.GetPlayerMovementVector2();
        rb.MovePosition(rb.position + moveVector * (Speed * Time.fixedDeltaTime));
        isForwardRunning = moveVector.y < -minMovementSpeed;
        isBackwardRunning = moveVector.y > minMovementSpeed;
        isRightRunning = moveVector.x > minMovementSpeed;
        isLeftRunning = moveVector.x < -minMovementSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            GameOver();
    }

    private void GameOver()
    {
        gameOver.transform.position = gameObject.transform.position;
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
