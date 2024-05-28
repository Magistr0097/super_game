using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gameInput;
    public static PlayerMovement Instance { get; private set; }
    public KeyCode interactionKey;
    public bool IsRightRunning { get; private set; }
    public bool IsLeftRunning { get; private set; }
    public bool IsForwardRunning { get; private set; }
    public bool IsBackwardRunning { get; private set; }
    
    public GameObject gameOver; //find way to delete it

    public GameObject interactionHint;
    private readonly float minMovementSpeed = 0.1f;
    private const float Speed = 7f;
    private Rigidbody2D rb;
    private GameObject interactionObj;
    
    
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(interactionKey) || interactionObj == null) return;
        gameInput.SetActive(false);
        IsForwardRunning = false;
        IsBackwardRunning = false;
        IsRightRunning = false;
        IsLeftRunning = false;
        interactionHint.SetActive(false);
        interactionObj.GetComponent<DialogueStarter>().StartDialogue();
        interactionObj = null;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (!gameInput.activeSelf) return;
        var moveVector = GameInput.Instance.GetPlayerMovementVector2();
        rb.MovePosition(rb.position + moveVector * (Speed * Time.fixedDeltaTime));
        IsForwardRunning = moveVector.y < -minMovementSpeed;
        IsBackwardRunning = moveVector.y > minMovementSpeed;
        IsRightRunning = moveVector.x > minMovementSpeed;
        IsLeftRunning = moveVector.x < -minMovementSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            GameOver();
        if (collision.gameObject.CompareTag("Interaction"))
        {
            interactionObj = collision.gameObject;
            interactionHint.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interaction"))
        {
            interactionObj = collision.gameObject;
            interactionHint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Interaction"))
        {
            interactionObj = null;
            interactionHint.SetActive(false);
        }
    }

    private void GameOver()
    {
        gameOver.transform.position = gameObject.transform.position;
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadData(Save.MainPlayer save)
    {
        transform.position = new Vector3(save.position.x, save.position.y, save.position.z);
    }

}
