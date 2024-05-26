using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMenu : MonoBehaviour
{
    public KeyCode keyCode;
    private GameObject[] menu;
    private bool menuOpen = false;
    void Start()
    {
        menu = GameObject.FindGameObjectsWithTag("Menu");
        CloseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode) && menuOpen)
            CloseMenu();
        else if (Input.GetKeyDown(keyCode))
            OpenMenu();
    }

    private void OpenMenu()
    {
        Time.timeScale = 0f;
        menuOpen = true;
        foreach (var menuObj in menu)
            menuObj.SetActive(true);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        menuOpen = false;
        foreach (var menuObj in menu)
            menuObj.SetActive(false);
    }
}
