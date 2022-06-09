using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Animator doorAnimator;
    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
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
}
