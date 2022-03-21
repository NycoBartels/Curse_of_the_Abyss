using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate : MonoBehaviour
{
    [SerializeField] private GameObject EventObject;

    void Start()
    {
        EventObject.GetComponent<RoomEventTrigger>().triggers += 1;
    }


    void Update()
    {
        
    }
}
