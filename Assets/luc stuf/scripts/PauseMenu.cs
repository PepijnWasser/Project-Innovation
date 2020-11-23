using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject MainMenu;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        MainMenu.SetActive(true);
        Resume();
    }
    public void QuitGame()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }
}

//