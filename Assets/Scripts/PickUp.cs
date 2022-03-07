using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Transform dest;

    private void OnMouseDown() {
        //GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = dest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
    }

    private void OnMouseRelease() {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<BoxCollider>().enabled = true;
    }

}
