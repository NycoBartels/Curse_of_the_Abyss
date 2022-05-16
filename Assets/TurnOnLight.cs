using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLight : MonoBehaviour
{
    private Light light;
    private BoxCollider coll;
    [SerializeField] private float LightRange;
    [SerializeField] private float LightIntensity;
    [SerializeField] private float ActivationTime;
    private float lightIntensityInc;
    private bool turnedOn;


    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnedOn)
        {
            IncreaseLight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TurnOn();
    }

    public void TurnOn()
    {
        turnedOn = true;
        lightIntensityInc = LightIntensity / ActivationTime;
    }

    private void IncreaseLight()
    {
        if (light.intensity >= LightIntensity) return;

        light.intensity += lightIntensityInc * Time.deltaTime;
    }
}
