using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerActivate : MonoBehaviour
{
    public bool isTouched = false;

    public static Action<GameObject> AddMePlease;
    public static Action<GameObject> RemoveMePlease;

    [SerializeField]
    RoomEventTrigger roomEventTrigger;

    private void Start()
    {
        roomEventTrigger.triggers++;
    }

    private void Update()
    {
        if (isTouched)
        {
            AddMePlease?.Invoke(this.gameObject);
        }
        else
        {
            RemoveMePlease?.Invoke(this.gameObject);
        }
    }
}
