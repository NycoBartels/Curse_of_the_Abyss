using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : MonoBehaviour
{
    [SerializeField]
    private bool leverActive;
    [SerializeField]
    private GameObject leverHandle;
    [SerializeField]
    private float turnTime;
    [SerializeField]
    private GameObject door;

    public bool interacted = false;

    private Quaternion inactiveRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion activeRotation = Quaternion.Euler(-60, 0, 0);


    

    public void RotateLever()
    {
        if (!leverActive)
        {
            leverActive = true;
            door.GetComponent<Door>().OpenDoor();
            StartCoroutine(RotateLeverHandle(inactiveRotation, activeRotation, turnTime));
        } else
        {
            leverActive = false;
            door.GetComponent<Door>().CloseDoor();
            StartCoroutine(RotateLeverHandle(activeRotation, inactiveRotation, turnTime));
        }
    }


    IEnumerator RotateLeverHandle (Quaternion startRotation, Quaternion endRotation, float timeToTurn)
    {
        if(timeToTurn > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + timeToTurn;

            leverHandle.transform.rotation = startRotation;
            yield return null;

            while(Time.time < endTime)
            {
                float progress = (Time.time - startTime) / timeToTurn;
                leverHandle.transform.rotation = Quaternion.Slerp(startRotation, endRotation, progress);
                yield return null;
            }
        }
        leverHandle.transform.rotation = endRotation;
    }


    public bool IsLeverActive()
    {
        return leverActive;
    }
}
