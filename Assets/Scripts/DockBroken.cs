using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockBroken : MonoBehaviour
{
    public bool isBroken;
    [SerializeField] private GameObject crystal;

    // Update is called once per frame
    void Update()
    {
        if(isBroken)
        {
            crystal.SetActive(false);
            GetComponent<DrawLightBeam>().active = false;
        } else
        {
            crystal.SetActive(true);
            GetComponent<DrawLightBeam>().active = true;
        }
    }
}
