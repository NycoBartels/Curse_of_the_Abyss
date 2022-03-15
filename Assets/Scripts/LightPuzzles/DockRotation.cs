using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockRotation : MonoBehaviour
{
    [SerializeField] private int rotationNo;

    void Start()
    {
        
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, rotationNo * 45f, 0);
    }
}
