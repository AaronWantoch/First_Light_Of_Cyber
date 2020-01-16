using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int amount = 5;

    private void OnTriggerEnter(Collider other)
    {
        Ammo ammo = 
            other.GetComponent<Ammo>();
        if(!ammo)
        {
            return;
        }

        ammo.IncreaseAmmoAmount(ammoType, amount);

        AmmoType currentAmmoType = FindObjectOfType<Weapon>().GetCurrentAmmoType();
        if (ammoType == currentAmmoType)
        ammo.UpdateUI(ammoType);


        Destroy(this.gameObject);
    }

}
