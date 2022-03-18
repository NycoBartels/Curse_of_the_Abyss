using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HealthVolume : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] GameObject player;

    public Volume volume;
    Vignette vignette;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        volume.profile.TryGet<Vignette>(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.health >= 0)
        {
            vignette.intensity.value = 0.80f;
        }else if(playerHealth.health >= 1.99f)
        {
            vignette.intensity.value = 0.60f;
        }
        else if (playerHealth.health >= 3.99f)
        {
            vignette.intensity.value = 0.40f;
        }
        else if (playerHealth.health >= 5.99f)
        {
            vignette.intensity.value = 0.20f;
        } else
        {
            vignette.intensity.value = 0;
        }
        //vignette.intensity.value = 
    }
}
