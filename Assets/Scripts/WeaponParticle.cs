using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParticle : WeaponComponent
{
    [SerializeField] ParticleSystem muzzleFlash;
    protected override void WeaponFired()
    {
        muzzleFlash.Play();
    }

   
}
