using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject optionsSelectables;
    public GameObject settingScreen;
    public GameObject creditScreen;
    public GameObject controlScreen;

    public void NewGame()
    {
        SceneManager.LoadScene("GreyBox");
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void Credits()
    {
        optionsSelectables.SetActive(false);
        creditScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void BackButton()
    {
        optionsSelectables.SetActive(true);
        settingScreen.SetActive(false);
        creditScreen.SetActive(false);
        controlScreen.SetActive(false);
    }

    public void Controls()
    {
        settingScreen.SetActive(false);
        controlScreen.SetActive(true);
    }

    public void GameSettings()
    {
        optionsSelectables.SetActive(false);
        settingScreen.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
