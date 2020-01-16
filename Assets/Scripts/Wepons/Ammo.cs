using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    [SerializeField] Text ammoText;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount = 10;
    }

    public void DecreaseAmmoAmount(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseAmmoAmount(AmmoType ammoType, int additionalAmmo)
    {
        GetAmmoSlot(ammoType).ammoAmount += additionalAmmo;
    }

    public int GetAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == ammoType)
                return ammoSlot;
        }

        Debug.LogError("Ammo type don't exist on player");
        return null;
    }

    public void UpdateUI(AmmoType ammoType)
    {
        ammoText.text = GetAmmoSlot(ammoType).ammoAmount.ToString();
    }
}
