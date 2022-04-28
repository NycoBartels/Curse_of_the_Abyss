using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagerTest : MonoBehaviour
{
    [SerializeField]
    private List<Transform> triggersList = new List<Transform>();

    [SerializeField]
    Animator doorAnimator;

    private void OnEnable()
    {
        //LaserTestDummyV2.callPuzzleManager += AssessGameState;
    }

    private void OnDisable()
    {
        //LaserTestDummyV2.callPuzzleManager -= AssessGameState;
    }

    void AssessGameState(int activatedTriggers)
    {
        if (activatedTriggers == triggersList.Count)
        {
            doorAnimator.SetBool("openDoor", true);
        }
    }
}
