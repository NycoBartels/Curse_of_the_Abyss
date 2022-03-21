using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerDummy : MonoBehaviour
{
    public int triggers;

    [SerializeField]
    private List<GameObject> triggersActivated;

    [SerializeField]
    Animator doorAnimator;

    private void OnEnable()
    {
        DoorTrigger.AddMePlease += AddTrigger;
        DoorTrigger.RemoveMePlease += RemoveTrigger;
    }

    private void OnDisable()
    {
        DoorTrigger.AddMePlease -= AddTrigger;
        DoorTrigger.RemoveMePlease -= RemoveTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggersActivated.Count == triggers)
        {
            if (doorAnimator.GetBool("openDoor") == true) return;

            doorAnimator.SetBool("openDoor", true);
        } else
        {
            if (doorAnimator.GetBool("openDoor") == false) return;

            doorAnimator.SetBool("openDoor", false);
        }
    }


    public void AddTrigger(GameObject activatedTrigger)
    {
        if (!triggersActivated.Contains(activatedTrigger))
        {
            triggersActivated.Add(activatedTrigger);
        }
    }

    public void RemoveTrigger(GameObject deactivatedTrigger)
    {
        if (triggersActivated.Contains(deactivatedTrigger))
        {
            triggersActivated.Remove(deactivatedTrigger);
        }
    }
}
