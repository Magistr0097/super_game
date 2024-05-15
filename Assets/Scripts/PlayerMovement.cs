using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject gameOver; //find way to delete it

    private readonly float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private float movementAxisHorizontal;
    private float movementAxisVertical;
    private static readonly int DirectionHorizontal = Animator.StringToHash("directionHorizontal");
    private static readonly int DirectionVertical = Animator.StringToHash("directionVertical");

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        movementAxisHorizontal = Input.GetAxis("Horizontal");
        movementAxisVertical = Input.GetAxis("Vertical");

        animator.SetFloat(DirectionHorizontal, movementAxisHorizontal);
        animator.SetFloat(DirectionVertical, movementAxisVertical);

        var movement = new Vector2(movementAxisHorizontal, movementAxisVertical);
        rb.velocity = movement * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            GameOver();
    }

    void GameOver()
    {
        gameOver.transform.position = gameObject.transform.position;
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
