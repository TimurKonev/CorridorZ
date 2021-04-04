using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;

    public static event Action<Weapon> OnWeaponChanged = delegate { };

    private void Awake()
    {
        SwitchToWeapon(weapons[0]);
    }
    void Update()
    {
        foreach (var weapon in weapons)
        {
            if (Input.GetKeyDown(weapon.WeaponHotKey))
            {
                SwitchToWeapon(weapon);
                break;
            }
        }
    }

    void SwitchToWeapon(Weapon weaponToSwitchTo)
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == weaponToSwitchTo);
        }
        OnWeaponChanged(weaponToSwitchTo);
    }
}
