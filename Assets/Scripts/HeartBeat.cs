using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public AudioSource source;
    public AudioClip heartbeat;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            source.PlayOneShot(heartbeat);
        }
    }
}
