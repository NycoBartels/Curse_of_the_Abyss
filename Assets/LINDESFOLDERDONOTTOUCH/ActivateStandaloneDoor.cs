using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStandaloneDoor : MonoBehaviour
{
    [SerializeField]
    private List<Transform> levers = new List<Transform>();

    [SerializeField]
    private List<Animator> doorAnimator = new List<Animator>();


    private void Update()
    {
        bool allLeversActive = true;

        foreach (Transform lever in levers)
        {
            if (!lever.GetComponent<LeverInteract>().IsLeverActive())
            {
                allLeversActive = false;
            }
        }

        if (allLeversActive)
        {
            foreach (Animator door in doorAnimator)
            {
                door.SetBool("openDoor", true);
            }
        }
    }


}
