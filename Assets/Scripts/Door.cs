using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Animator doorAnimator;
    AudioSource sound;
    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        doorAnimator.SetBool("openDoor", true);
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("openDoor", false);
    }

    public void CreakyDoorSFX()
    {
        sound.Play();
    }

}
