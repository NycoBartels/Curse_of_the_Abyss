using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelect : MonoBehaviour
{
    [SerializeField] private Material glow;
    [SerializeField] private Material mirror;
    [SerializeField] private Material dock;
    private GameObject lastObjectMirror;
    private GameObject lastObjectDock;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            Component mirrorScript = hitObject.GetComponentInParent<MirrorRotation>();
            Component dockScript = hitObject.GetComponent<DockRotation>();
            if (mirrorScript != null)
            {
                hitObject.GetComponentInParent<MeshRenderer>().material = glow;

                if (lastObjectMirror == null)
                {
                    lastObjectMirror = hitObject.gameObject;
                }
                else if (hitObject.gameObject != lastObjectMirror)
                {
                    lastObjectMirror.GetComponentInParent<MeshRenderer>().material = mirror;
                    lastObjectMirror = hitObject.gameObject;
                }
            }
            else if (dockScript != null)
            {
                hitObject.GetComponent<MeshRenderer>().material = glow;
                lastObjectDock = hitObject;
            } else
            {
                if(lastObjectDock != null)
                {
                    lastObjectDock.GetComponent<MeshRenderer>().material = dock;
                }
                if(lastObjectMirror != null)
                {
                    lastObjectMirror.GetComponentInParent<MeshRenderer>().material = mirror;
                }
                
            }
        }
    }
}
