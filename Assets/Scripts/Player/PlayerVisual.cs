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
        animator.SetBool("isRightRunning", playerMovementInstance.isRightRunning);
        animator.SetBool("isLeftRunning", playerMovementInstance.isLeftRunning);
        animator.SetBool("isForwardRunning", playerMovementInstance.isForwardRunning);
        animator.SetBool("isBackwardRunning", playerMovementInstance.isBackwardRunning);
    }
}
