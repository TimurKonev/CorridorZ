using System;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Animator))]
public class WeaponAnimation : WeaponComponent
{
    Animator animator;

    protected override void WeaponFired()
    {
        animator.SetTrigger("Fire");
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

}
