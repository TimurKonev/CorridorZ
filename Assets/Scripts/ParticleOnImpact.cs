using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnImpact : MonoBehaviour
{
    [SerializeField] ProjectileImpact particlePrefab;

     void OnCollisionEnter(Collision collision)
    {
        particlePrefab.Get<ProjectileImpact>(transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
    }
}
