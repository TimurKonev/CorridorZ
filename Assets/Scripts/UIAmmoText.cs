using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAmmoText : MonoBehaviour
{
    TextMeshProUGUI tmproText;
    WeaponAmmo currentWeaponAmmo;

    void Awake()
    {
        tmproText = GetComponent<TMPro.TextMeshProUGUI>();
        Inventory.OnWeaponChanged += Inventory_OnWeaponChanged;
    }

    void Inventory_OnWeaponChanged(Weapon weapon)
    {
        if(currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChanged -= CurrentWeaponAmmo_OnAmmoChanged;
        }

        currentWeaponAmmo = weapon.GetComponent<WeaponAmmo>();

        if(currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChanged += CurrentWeaponAmmo_OnAmmoChanged;
            tmproText.text = currentWeaponAmmo.GetAmmoText();
        }
        else
        {
            tmproText.text = "Unlimited";
        }
    }

    private void CurrentWeaponAmmo_OnAmmoChanged()
    {
        tmproText.text = currentWeaponAmmo.GetAmmoText();
    }
}
