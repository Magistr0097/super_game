using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWaiting : MonoBehaviour
{
    public KeyCode keyCode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
            gameObject.SetActive(false);
    }
}
