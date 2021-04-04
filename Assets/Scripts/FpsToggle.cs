using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsToggle : MonoBehaviour
{
    [SerializeField] GameObject[] firstPersonObjects;
    [SerializeField] GameObject[] thirdPersonObjects;
    [SerializeField] KeyCode toggleKey = KeyCode.I;
    bool isFpsMode;
    Weapons weapons;

    void Awake()
    {
        FindObjectOfType<PlayerMovement>().GetComponent<Health>().OnDied += ToggleFPS_OnDied;
        weapons = FindObjectOfType<Weapons>();    
    }

     void ToggleFPS_OnDied()
    {
        
        if(weapons.IsFpsMode)
        {
            Toggle();
        }
    }

    void OnEnable()
    {
        ToggleObjectsForCurrentMode();
    }
    void Update()
    {
        if(Input.GetKeyDown(toggleKey))
        {
            Toggle();
        }
    }

    void Toggle()
    {
        isFpsMode = !isFpsMode;
        weapons.IsFpsMode = isFpsMode;

        ToggleObjectsForCurrentMode();
    }

    void ToggleObjectsForCurrentMode()
    {
        foreach (var gameObject in firstPersonObjects)
        {
            gameObject.SetActive(isFpsMode);
        }

        foreach (var gameObject in thirdPersonObjects)
        {
            gameObject.SetActive(!isFpsMode);
        }
    }
}
