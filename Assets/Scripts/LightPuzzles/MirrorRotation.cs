using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotation : MonoBehaviour
{
    [SerializeField] [Range(0, 16)] private int rotationNo;


    void Start()
    {
        
    }


    void Update()
    {
        transform.eulerAngles = new Vector3(0, rotationNo * 22.5f, 0);
    }
}
