using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    
    void Update()
    {

        if (Input.GetKey("escape"))
        {
            print("stfu");
            //Application.Quit();
        }

    }
}
