using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class cinematicScript : MonoBehaviour
{
    public VideoPlayer video;
    float elapsedTime;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 21f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
