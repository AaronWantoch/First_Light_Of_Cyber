using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public void DecreaseAmmoAmount()
    {
        ammoAmount--;
    }

    public void IncreaseAmmoAmount(int additionalAmmo)
    {
        ammoAmount += additionalAmmo;
    }

    public int GetAmmoAmount()
    {
        return ammoAmount;
    }
}
