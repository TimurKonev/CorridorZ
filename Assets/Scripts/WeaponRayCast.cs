using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRayCast : WeaponComponent
{
    [SerializeField] float maxDistance;
    [SerializeField] Transform firePoint;
    [SerializeField] LayerMask layerMask;
    [SerializeField] PooledMonoBehaviour decalPrefab;
    [SerializeField] int damageAmount = 1;

    RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Ray ray = weapon.IsInAimMode ? Camera.main.ViewportPointToRay(Vector3.one / 2f) : 
            new Ray (firePoint.position, firePoint.forward);

        if(Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            Health health = hitInfo.collider.GetComponent<Health>();

            if (health != null)
            {
                health.TakeHit(damageAmount);
            }    
            else
            {
                SpawnDecal(hitInfo.point, hitInfo.normal);
            }
        }
    }

    private void SpawnDecal(Vector3 point, Vector3 normal)
    {
        var decal = decalPrefab.Get<PooledMonoBehaviour>(point, Quaternion.LookRotation(-normal));
        decal.ReturnToPool(5f);
    }
}
