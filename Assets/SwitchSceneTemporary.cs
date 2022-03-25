using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneTemporary : MonoBehaviour
{
    public GameObject eventSystem;
   
    public void SwitchToGame()
    {
        eventSystem.SetActive(false);

        SceneManager.LoadScene("Light Puzzles");
        Cursor.visible = false;
    }

}
