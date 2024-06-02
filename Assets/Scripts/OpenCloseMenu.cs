using UnityEngine;

public class OpenCloseMenu : MonoBehaviour
{
    public KeyCode keyCode;
    private GameObject menu;
    private bool menuOpen;
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        CloseMenu();
    }
    
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
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        menuOpen = false;
        gameObject.GetComponent<ActivateObj>().DisActivate();
        menu.SetActive(false);
    }
}
