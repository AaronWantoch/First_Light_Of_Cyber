using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] float lightIntensivityDecay = 0.1f;
    [SerializeField] float lightAngleDecay = 0.5f;
    [SerializeField] float minLightAngle = 15f;

    float defaultIntensivity;
    float defaultAngle;

    Light light;


    private void Start()
    {
        light = GetComponent<Light>();
        defaultIntensivity = light.intensity;
        defaultAngle = light.spotAngle;
    }

    void Update()
    {
        if (light.spotAngle > minLightAngle)
            light.spotAngle -= lightAngleDecay * Time.deltaTime;

        light.intensity -= lightIntensivityDecay * Time.deltaTime;
    }

    public void RestoreDefaultValues()
    {
        light.intensity = defaultIntensivity;
        light.spotAngle = defaultAngle;
    }

}
