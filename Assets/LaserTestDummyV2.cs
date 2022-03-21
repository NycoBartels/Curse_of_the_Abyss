using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTestDummyV2 : MonoBehaviour
{
    private string selectionTag = "Door Trigger";

    [SerializeField]
    private List<Transform> selectedTransforms = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedTransforms.Count != 0)
        {
            for (int i=0; i <= selectedTransforms.Count; i++)
            {
                selectedTransforms.Remove(selectedTransforms[i]);
            }
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.name);

            Transform selection = hit.transform;
            if (selection.CompareTag(selectionTag))
            {
                selectedTransforms.Add(selection);
            }

        }
    }
}
