using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChildrenOnEnter : MonoBehaviour
{
    private void Awake()
    {
        ToggleChildren(false);
    }

    private void ToggleChildren(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            ToggleChildren(true);
        }
    }

    private void OnValidate()
    {
        Collider collider = GetComponent<Collider>();
        if(collider == null)
        {
            collider = gameObject.AddComponent<SphereCollider>();
            ((SphereCollider)collider).radius = 10f;       
        }

        collider.isTrigger = true;
    }
}
