using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : PooledMonoBehaviour
{

    
    private void OnCollisionEnter(Collision collision)
    {
        ReturnToPool();
    }

   
}
