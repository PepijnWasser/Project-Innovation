using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public void PlayGame()
    {
        MainMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
