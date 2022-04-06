using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicatorDoor : MonoBehaviour
{
    private Material myMaterial;
    [SerializeField]
    private GameObject myTarget;

    void Start()
    {
        myMaterial = myTarget.GetComponent<Renderer>().material;
        this.GetComponent<Renderer>().material = myMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial = myTarget.GetComponent<Renderer>().material;

        if(this.GetComponent<Renderer>().material != myMaterial)
        {
            this.GetComponent<Renderer>().material = myMaterial;
        }
    }
}
