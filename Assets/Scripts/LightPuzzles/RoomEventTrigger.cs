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
    private List<Animator> doorAnimator = new List<Animator>();

    [SerializeField]
    private List<GameObject> lights = new List<GameObject>();

    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

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
            foreach(Animator door in doorAnimator)
            {
                door.SetBool("openDoor", true);
                PlayJingle();
                //TO DO: play this only the first time the puzzle gets solved
            }
            
        }
        if (lights != null) {
            foreach (GameObject light in lights) {
                light.GetComponent<TurnOnLight>().TurnOn();
            }
        }
    }

    public void PlayJingle()
    {
        sound.PlayDelayed(1f);
    }

}
