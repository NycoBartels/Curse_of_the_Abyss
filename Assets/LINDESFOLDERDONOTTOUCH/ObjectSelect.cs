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
    private GameObject lastObjectCrystal;
    private GameObject pickUpUI;
    private GameObject placeUI;
    private PlayerInventory _inventory;


    void Start()
    {
        pickUpUI = GameObject.FindGameObjectWithTag("PickUI");
        placeUI = GameObject.FindGameObjectWithTag("PlaceUI");
        pickUpUI.SetActive(false);
        placeUI.SetActive(false);
        _inventory = GetComponent<PlayerInventory>();
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
            Component crystalScript = hitObject.GetComponent<PickUpCrystal>();
            if (mirrorScript != null && hitObject.name != "Side Blocks")
            {
                Transform mirrorHandle1 = hitObject.transform.parent.Find("Armature/Bone/mirror handle.001");
                Transform mirrorHandle2 = hitObject.transform.Find("mirror handle");

                if (mirrorHandle1 != null)
                {
                    mirrorHandle1.GetComponent<MeshRenderer>().material = glow;
                }
                if (mirrorHandle2 != null)
                {
                    mirrorHandle2.GetComponent<MeshRenderer>().material = glow;
                }


                if (lastObjectMirror == null)
                {
                    lastObjectMirror = hitObject.gameObject;
                }
                else if (hitObject.gameObject != lastObjectMirror)
                {
                    lastObjectMirror.transform.parent.Find("Armature/Bone/mirror handle.001").GetComponent<MeshRenderer>().material = mirror;
                    //lastObjectMirror.transform.Find("mirror handle01").GetComponent<MeshRenderer>().material = mirror;
                    lastObjectMirror = hitObject.gameObject;
                }
            }
            else if (dockScript != null)
            {
                Transform dockMaybe = hitObject.transform.Find("Base/big metal thingy/handle");

                if (dockMaybe != null)
                {
                    dockMaybe.GetComponent<MeshRenderer>().material = glow;
                }

                if (hitObject.GetComponent<DockBroken>().isBroken == true && _inventory.crystalAmount >= 1)
                {
                    placeUI.SetActive(true);
                }

                lastObjectDock = hitObject;

            }
            else if (consoleScript != null)
            {
                hitObject.GetComponent<MeshRenderer>().material = glow;
                lastObjectConsole = hitObject;

                GameObject[] mirrorListObj = hitObject.GetComponent<MirrorConsole>().mirrorList;

                for (int mirrorNo = 0; mirrorNo < mirrorListObj.Length; mirrorNo++)
                {
                    mirrorListObj[mirrorNo].gameObject.transform.parent.Find("Armature/Bone/mirror handle.001").GetComponent<MeshRenderer>().material = glow;
                    //mirrorListObj[mirrorNo].gameObject.transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material = glow;
                }

            }
            else if (crystalScript != null)
            {
                hitObject.GetComponent<MeshRenderer>().material = glow;
                pickUpUI.SetActive(true);
                lastObjectCrystal = hitObject;
            }

            else
            {
                if (lastObjectDock != null)
                {
                    lastObjectDock.transform.Find("Base/big metal thingy/handle").GetComponent<MeshRenderer>().material = dock;
                    placeUI.SetActive(false);
                }
                if (lastObjectMirror != null)
                {
                    Transform mirrorHandle1 = lastObjectMirror.transform.parent.Find("Armature/Bone/mirror handle.001");
                    Transform mirrorHandle2 = lastObjectMirror.transform.Find("mirror handle");

                    if (mirrorHandle1 != null)
                    {
                        mirrorHandle1.GetComponent<MeshRenderer>().material = mirror;
                    }
                    if (mirrorHandle2 != null)
                    {
                        mirrorHandle2.GetComponent<MeshRenderer>().material = mirror;
                    }
                }
                if (lastObjectConsole != null)
                {
                    lastObjectConsole.GetComponent<MeshRenderer>().material = dock;

                    GameObject[] mirrorListObj = lastObjectConsole.GetComponent<MirrorConsole>().mirrorList;

                    for (int mirrorNo = 0; mirrorNo < mirrorListObj.Length; mirrorNo++)
                    {
                        mirrorListObj[mirrorNo].gameObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = mirror;
                        mirrorListObj[mirrorNo].gameObject.transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material = mirror;
                    }
                }
                if (lastObjectCrystal != null)
                {
                    lastObjectCrystal.GetComponent<MeshRenderer>().material = mirror;
                    pickUpUI.SetActive(false);
                }

            }
        }
    }
}
