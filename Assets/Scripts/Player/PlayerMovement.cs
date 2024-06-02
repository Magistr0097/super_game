using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CameraFollow mainCamera;
    public GameObject gameInput;
    public GameObject saveLoad;
    public static PlayerMovement Instance { get; private set; }
    public KeyCode interactionKey;
    public bool IsRightRunning { get; private set; }
    public bool IsLeftRunning { get; private set; }
    public bool IsForwardRunning { get; private set; }
    public bool IsBackwardRunning { get; private set; }

    public GameObject gameOver; //find way to delete it
    public GameObject circle;
    public GameObject interactionHint;
    public GameObject Delay;
    public GameObject Menu;
    public GameObject Dialogue;
    [SerializeField] private Text delayText;
    private readonly float minMovementSpeed = 0.1f;
    private const float Speed = 7f;
    private Rigidbody2D rb;
    private GameObject interactionObj;
    private float teleportDelay = 10f;
    private bool mouseClicked = false;

    private void Start()
    {
        // delayText = Delay.GetComponent<Text>();

        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        if (Variables.LoadedSave != null)
        {
            saveLoad.GetComponent<SaveLoad>().Load(Variables.LoadedSave);
            Variables.LoadedSave = null;
        }
        else if (!Variables.IsFirstStartGame)
        {
            switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
            {
                case "Town":
                    if (Variables.ForestStage <= 1)
                        transform.position = Variables.RespawnPoints[RespawnPositions.OnEnterToTownBeginning];
                    else
                        transform.position = Variables.RespawnPoints[RespawnPositions.OnEnterToTown];
                    break;
                case "Forest":
                    if (Variables.ForestStage == 2)
                        transform.position = Variables.RespawnPoints[RespawnPositions.OnExitFromRoom];
                    else
                        transform.position = Variables.RespawnPoints[RespawnPositions.OnEnterToForest];
                    break;
            }
        }
        else
        {
            Variables.IsFirstStartGame = false;
            transform.position = Variables.RespawnPoints[RespawnPositions.Initial];
        }

        mainCamera.CenterOnPlayer();
    }

    private void Update()
    {
        if (!Menu.activeSelf && !Dialogue.activeSelf)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (teleportDelay >= 10)
                Delay.GetComponent<AutoDisable>().Disable();
            delayText.text = $"Перезарядка {10 - teleportDelay:F1} секунд";

            if (Variables.ForestStage >= 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (teleportDelay >= 10)
                    {
                        mouseClicked = true;
                        circle.SetActive(true);
                        Delay.GetComponent<AutoDisable>().Disable();
                        Time.timeScale = 0.5f;
                    }
                    else
                    {
                        Delay.SetActive(true);
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    if (teleportDelay >= 10 && mouseClicked)
                    {
                        circle.SetActive(false);
                        Time.timeScale = 1f;
                        if (IsMouseNearPlayer(mousePos))
                        {
                            rb.transform.position = new Vector3(mousePos.x, mousePos.y, rb.transform.position.z);
                            teleportDelay = 0f;
                        }
                    }

                    mouseClicked = false;
                }

                teleportDelay += Time.deltaTime;
            }
        }

        if (!Input.GetKeyDown(interactionKey) || interactionObj == null) return;
        gameInput.SetActive(false);
        IsForwardRunning = false;
        IsBackwardRunning = false;
        IsRightRunning = false;
        IsLeftRunning = false;
        interactionHint.SetActive(false);
        interactionObj.GetComponent<IDialogueStarter>().StartDialogue();
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interaction"))
        {
            interactionObj = collision.gameObject;
            interactionHint.SetActive(true);
        }
    }

    private bool IsMouseNearPlayer(Vector3 mousePosition)
    {
        return Math.Sqrt((rb.position.x - mousePosition.x) * (rb.position.x - mousePosition.x) +
                         (rb.position.y - mousePosition.y) * (rb.position.y - mousePosition.y)) < 5;
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