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
    private GameObject lastObjectConsole;


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
            Component consoleScript = hitObject.GetComponent<MirrorConsole>();

            if (mirrorScript != null && hitObject.name != "Side Blocks")
            {
                Transform objHandle = hitObject.transform.Find("mirror handle");
                Transform objHandle2 = hitObject.transform.Find("mirror handle01");
                if(objHandle != null && objHandle2 != null)
                {
                    objHandle.GetComponent<MeshRenderer>().material = glow;
                    objHandle2.GetComponent<MeshRenderer>().material = glow;

                    if (lastObjectMirror == null)
                    {
                        lastObjectMirror = hitObject.gameObject;
                    }
                    else if (hitObject.gameObject != lastObjectMirror)
                    {
                        objHandle.GetComponent<MeshRenderer>().material = mirror;
                        objHandle2.GetComponent<MeshRenderer>().material = mirror;
                        lastObjectMirror = hitObject.gameObject;
                    }
                }
                
            }
            else if (dockScript != null)
            {
                Transform obj = hitObject.transform.Find("handle");
                if (obj != null)
                {
                    obj.GetComponent<MeshRenderer>().material = glow;
                    lastObjectDock = hitObject;
                }
            } else if (consoleScript != null)
            {
                hitObject.GetComponent<MeshRenderer>().material = glow;
                lastObjectConsole = hitObject;

                GameObject[] mirrorListObj = hitObject.GetComponent<MirrorConsole>().mirrorList;

                for (int mirrorNo = 0; mirrorNo < mirrorListObj.Length; mirrorNo++)
                {
                    mirrorListObj[mirrorNo].gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = glow;
                    mirrorListObj[mirrorNo].gameObject.transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material = glow;
                }

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
                if(lastObjectConsole != null)
                {
                    lastObjectConsole.GetComponent<MeshRenderer>().material = dock;

                    GameObject[] mirrorListObj = lastObjectConsole.GetComponent<MirrorConsole>().mirrorList;

                    for (int mirrorNo = 0; mirrorNo < mirrorListObj.Length; mirrorNo++)
                    {
                        mirrorListObj[mirrorNo].gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = mirror;
                        mirrorListObj[mirrorNo].gameObject.transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material = mirror;
                    }
                }
                
            }
        }
    }
}
