using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Flashlight flashlight = other.GetComponentInChildren<Flashlight>();
        if (flashlight)
        {
            flashlight.RestoreDefaultValues();

            Destroy(gameObject);
        }
    }
}
