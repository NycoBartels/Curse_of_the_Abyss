using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    AudioSource sound;
    [SerializeField] private AudioClip[] clips;


    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void ChooseRandomFootsound()
    {
        sound.clip = clips[Random.Range(0, 3)];
    }

    public void PlayStepSFX()
    {
        ChooseRandomFootsound();
        sound.Play();
    }
}
