using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadIntro() {
        SceneManager.LoadScene("Intro");
    }
    public void LoadGame() {
        SceneManager.LoadScene("GreyBox");
    }
    public void LoadOptions() {
        SceneManager.LoadScene("Options");
    }
    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Exit() {
        Application.Quit();
    }

}
