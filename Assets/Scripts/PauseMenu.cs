using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public float timeBetweenPresses = 0.5f;
    private Animator pauseAnimator;

    private float timestamp;

    //public GameObject pauseMenuUI;

    void Start()
    {
        pauseAnimator = GameObject.Find("TornPage").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timestamp && (Input.GetKeyDown(KeyCode.Escape)) )
        {
            if (IsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        //pauseMenuUI.SetActive(false);
        pauseAnimator.SetTrigger("Close");
        //Time.timeScale = 1f;
        IsPaused = false;
        timestamp = Time.time + timeBetweenPresses;
    }

    void Pause ()
    {
        //pauseMenuUI.SetActive(true);
        pauseAnimator.SetTrigger("Open");
        //Time.timeScale = 0f;
        IsPaused = true;
        timestamp = Time.time + timeBetweenPresses;
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
