using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

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

    // Update is called once per frame
    void Update()
    {
        movementAxisHorizontal = Input.GetAxis("Horizontal");
        movementAxisVertical = Input.GetAxis("Vertical");
        animator.SetFloat(DirectionHorizontal, movementAxisHorizontal);
        animator.SetFloat(DirectionVertical, movementAxisVertical);
    }

    private void FixedUpdate()
    {
        rb.position += new Vector2(movementAxisHorizontal, movementAxisVertical) * (speed * Time.deltaTime);
    }
}
