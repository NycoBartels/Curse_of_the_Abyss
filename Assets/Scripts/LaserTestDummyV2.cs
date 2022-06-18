using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaserTestDummyV2 : MonoBehaviour
{
    private string selectionTag = "Door Trigger";

    [SerializeField]
    private List<Transform> selectedTransforms = new List<Transform>();

    //public static Action<int> callPuzzleManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == selectionTag)
            {
                if (!selectedTransforms.Contains(hit.transform))
                {
                    selectedTransforms.Add(hit.transform);
                    //callPuzzleManager?.Invoke(selectedTransforms.Count);
                }
            }
        }
    }
}
