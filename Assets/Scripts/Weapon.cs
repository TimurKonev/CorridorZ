using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] KeyCode weaponHotKey;
    [SerializeField] float fireDelay = 0.25f;


    float fireTimer;
    private WeaponAmmo ammo;

    public event Action OnFire = delegate { };
    public KeyCode WeaponHotKey { get { return weaponHotKey; } }

    public bool IsInAimMode { get { return Input.GetMouseButton(1) == false; } }

    void Awake()
    {
        ammo = GetComponent<WeaponAmmo>();
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (CanFire())
            {
                Fire();
            }
        }
    }


    bool CanFire()
    {
        if (ammo != null && ammo.IsAmmoReady() == false)
            return false;
        return fireTimer >= fireDelay;
    }
    void  Fire()
    {
        fireTimer = 0;
        OnFire();
    }
}
