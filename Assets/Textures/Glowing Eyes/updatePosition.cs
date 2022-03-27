using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatePosition : MonoBehaviour
{
    public GameObject eyes;

    // Update is called once per frame
    void Update()
    {
        transform.position = eyes.transform.position;
    }
}
