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


    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            Component mirrorScript = hitObject.GetComponentInParent<MirrorRotation>();
            Component dockScript = hitObject.GetComponent<DockRotation>();
            if (mirrorScript != null && hitObject.name != "Side Blocks")
            {
                hitObject.transform.Find("mirror handle").GetComponent<MeshRenderer>().material = glow;
                hitObject.transform.Find("mirror handle01").GetComponent<MeshRenderer>().material = glow;
                if (lastObjectMirror == null)
                {
                    lastObjectMirror = hitObject.gameObject;
                }
                else if (hitObject.gameObject != lastObjectMirror)
                {
                    lastObjectMirror.transform.Find("mirror handle").GetComponent<MeshRenderer>().material = mirror;
                    lastObjectMirror.transform.Find("mirror handle01").GetComponent<MeshRenderer>().material = mirror;
                    lastObjectMirror = hitObject.gameObject;
                }
            }
            else if (dockScript != null)
            {
                hitObject.transform.Find("handle").GetComponent<MeshRenderer>().material = glow;
                lastObjectDock = hitObject;
            } else
            {
                if(lastObjectDock != null)
                {
                    lastObjectDock.transform.Find("handle").GetComponent<MeshRenderer>().material = dock;
                }
                if(lastObjectMirror != null)
                {
                    lastObjectMirror.transform.Find("mirror handle").GetComponent<MeshRenderer>().material = mirror;
                    lastObjectMirror.transform.Find("mirror handle01").GetComponent<MeshRenderer>().material = mirror;
                }
                
            }
        }
    }
}
