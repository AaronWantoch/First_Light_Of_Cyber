using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Pickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int amount = 5;

    private void OnTriggerEnter(Collider other)
    {
        Ammo ammo = 
            other.GetComponentInChildren<Ammo>();
        if(!ammo)
        {
            return;
        }

        ammo.IncreaseAmmoAmount(ammoType, amount);

        Destroy(this.gameObject);
    }

}
