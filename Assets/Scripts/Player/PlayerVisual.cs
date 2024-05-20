using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var playerMovementInstance = PlayerMovement.Instance;
        animator.SetBool("isRightRunning", playerMovementInstance.IsRightRunning);
        animator.SetBool("isLeftRunning", playerMovementInstance.IsLeftRunning);
        animator.SetBool("isForwardRunning", playerMovementInstance.IsForwardRunning);
        animator.SetBool("isBackwardRunning", playerMovementInstance.IsBackwardRunning);
    }
}
