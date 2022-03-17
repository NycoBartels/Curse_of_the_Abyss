using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    int doorTriggerID;
    private bool doorOpened = false;
    [SerializeField]
    Animator doorAnimator;

    private void OnEnable()
    {
        LaserTestDummy.triggerDoor += OpenDoor;
    }

    private void OnDisable()
    {
        LaserTestDummy.triggerDoor -= OpenDoor;
    }

    public void OpenDoor(int triggerID, bool shouldOpenDoor)
    {
        if (triggerID == doorTriggerID)
        {
            doorAnimator.SetBool("openDoor", shouldOpenDoor);
        }
    }
}
