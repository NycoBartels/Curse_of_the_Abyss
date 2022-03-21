using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    int doorTriggerID;
    public bool isTouched = false;
    [SerializeField]
    Animator doorAnimator;

    public static Action<GameObject> AddMePlease;
    public static Action<GameObject> RemoveMePlease;

    [SerializeField]
    LevelManagerDummy levelManagerDummy;

    private void Start()
    {
        levelManagerDummy.triggers++;
    }

    private void Update()
    {
        if (isTouched)
        {
            AddMePlease?.Invoke(this.gameObject);
        } else
        {
            RemoveMePlease?.Invoke(this.gameObject);
        }
    }
    //private void OnEnable()
    //{
    //    LaserTestDummy.triggerDoor += OpenDoor;
    //}

    //private void OnDisable()
    //{
    //    LaserTestDummy.triggerDoor -= OpenDoor;
    //}

    //public void OpenDoor(int triggerID, bool shouldOpenDoor)
    //{
    //    if (triggerID == doorTriggerID)
    //    {
    //        doorAnimator.SetBool("openDoor", shouldOpenDoor);
    //    }
    //}
}
