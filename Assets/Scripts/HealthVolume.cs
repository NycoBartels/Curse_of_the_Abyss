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

    public int maxHealth = 10;

    public int freq = 0;
    public int amp = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        playerHealth = player.GetComponent<PlayerHealth>();
        volume.profile.TryGet<Vignette>(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        //if(playerHealth.health <= 2f)
        //{
        //    vignette.intensity.value = 0.400f;
        //}
        //else if(playerHealth.health <= 4f)
        //{
        //    vignette.intensity.value = 0.300f;
        //}
        //else if (playerHealth.health <= 6f)
        //{
        //    vignette.intensity.value = 0.200f;
        //}
        //else if (playerHealth.health <= 8f)
        //{
        //    vignette.intensity.value = 0.100f;
        //}
        //else if (playerHealth.health <= 10f)
        //{
        //    vignette.intensity.value = 0;
        //}

        // a calculation that determines the amount of vignette
        //that should fill the screen relative to the amount of health the player has.
        vignette.intensity.value = 0.500f - playerHealth.health / maxHealth / 2 + Mathf.Sin(Time.frameCount / playerHealth.health * freq) * (1 - playerHealth.health / maxHealth) * amp;
    }
}