using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEventTrigger : MonoBehaviour
{
    [SerializeField]
    private int puzzleManagerID;

    [SerializeField]
    private List<Transform> triggersList = new List<Transform>();

    [SerializeField]
    Animator doorAnimator;

    private void OnEnable()
    {
        DrawLightBeam.callPuzzleManager += AssessGameState;
    }

    private void OnDisable()
    {
        DrawLightBeam.callPuzzleManager -= AssessGameState;
    }

    void AssessGameState(int laserID, int activatedTriggers)
    {
        if (laserID != puzzleManagerID) return;

        if (activatedTriggers != triggersList.Count) return;

        if (doorAnimator != null)
        {
            doorAnimator.SetBool("openDoor", true);
        }
    }
}
