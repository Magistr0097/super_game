using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerPosition;
    void Awake()
    {
        gameObject.SetActive(false);
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(
            playerPosition.position.x,
            playerPosition.position.y,
            transform.position.z);
    }
}
