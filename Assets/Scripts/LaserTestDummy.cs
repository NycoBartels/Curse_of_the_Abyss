using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaserTestDummy : MonoBehaviour
{
    [SerializeField]
    private int laserID;

    public static Action<int, bool> triggerDoor;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);

            if (hit.transform.tag == "Door Trigger")
            {
                triggerDoor?.Invoke(laserID, true);
            }
        } else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);

            triggerDoor?.Invoke(laserID, false);
        }
    }
}
