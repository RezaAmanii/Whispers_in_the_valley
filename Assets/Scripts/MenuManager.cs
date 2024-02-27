using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    // Menu objects
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject howToPlayCanvas;

    // First selected option
    [SerializeField] private GameObject mainMenuCanvasFirst;
    [SerializeField] private GameObject howToPlayCanvasFirst;
    [SerializeField] private GameObject howToPlayBackButtonFirst;


    private bool isPaused;


    private void Start()
    {
        mainMenuCanvas.SetActive(false);
        howToPlayCanvas.SetActive(false);
    }

    private void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                pause();
            }
            else
            {
                unPause();
            }
        }
    }

    private void unPause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        CloseAllMenus();
    }


    private void CloseAllMenus()
    {
        mainMenuCanvas.SetActive(false);
        howToPlayCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }


    private void pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        OpenMainMenu();
    }



    private void OpenMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        howToPlayCanvas.SetActive(false);

        EventSystem.current.SetSelectedGameObject(mainMenuCanvasFirst);
    }



    public void OnHowToPlayPress()
    {
        OpenHowToPlayMenuHandle();
    }


    private void OpenHowToPlayMenuHandle()
    {
        howToPlayCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);

        //EventSystem.current.SetSelectedGameObject(howToPlayCanvasFirst);
        EventSystem.current.SetSelectedGameObject(howToPlayBackButtonFirst);
    }

    public void onResumePress()
    {
        unPause();
    }


    public void onHowToPlayBackButtonPress()
    {
        
        OpenMainMenu();
    }

    public void QuiteGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
