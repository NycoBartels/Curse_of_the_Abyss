using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockBroken : MonoBehaviour
{
    public bool isBroken;
    private GameObject crystal;

    void Awake()
    {
        crystal = transform.Find("light dock/dock").gameObject;
    }
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
