using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaserTestDummy : MonoBehaviour
{
    [SerializeField]
    private int laserID;

    public static Action<int, bool> triggerDoor;

    public List<GameObject> touchedTriggers;

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
                DoorTrigger doorTrigger = hit.transform.GetComponent<DoorTrigger>();

                if (doorTrigger != null)
                {
                    doorTrigger.isTouched = true;
                }

                if (!touchedTriggers.Contains(hit.transform.gameObject))
                {
                    touchedTriggers.Add(hit.transform.gameObject);
                }
            } else
            {
                if (touchedTriggers.Count != 0)
                {
                    for (int i = 0; i <= touchedTriggers.Count; i++)
                    {
                        DoorTrigger doorTrigger = touchedTriggers[i].GetComponent<DoorTrigger>();

                        if (doorTrigger != null)
                        {
                            doorTrigger.isTouched = false;
                        }

                        touchedTriggers.Remove(touchedTriggers[i]);
                    }
                }
            }
        } else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }
}
