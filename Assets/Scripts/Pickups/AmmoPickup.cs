using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;

    [SerializeField] int amount = 5;
    [SerializeField] float destroyDelay = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        Ammo ammo =
            other.GetComponent<Ammo>();
        if (!ammo)
        {
            return;
        }

        IncreaseAmmo(ammo);
        PlaySoundFX();

        Destroy(this.gameObject,destroyDelay);
    }

    private void PlaySoundFX()
    {
        GetComponent<AudioSource>().Play();
    }

    private void IncreaseAmmo(Ammo ammo)
    {
        ammo.IncreaseAmmoAmount(ammoType, amount);

        AmmoType currentAmmoType = FindObjectOfType<Weapon>().GetCurrentAmmoType();
        if (ammoType == currentAmmoType)
            ammo.UpdateUI(ammoType);
    }
}
