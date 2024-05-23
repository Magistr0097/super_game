using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float cameraStandOffset = 3f;
    [Range(0, 1)] 
    public float SmoothTime;
    
    private Transform playerPosition;
    private Vector3 newPosition;
    private Vector3 velocity = Vector3.zero;
    private readonly Vector3 cameraOffset = new(0, 0.7f, -10);
    

    private void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        // var play = GameObject.FindGameObjectsWithTag("Player");
    }


    void FixedUpdate()
    {
        newPosition = playerPosition.position;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition + cameraOffset, 
            ref velocity, SmoothTime);
    }
}
