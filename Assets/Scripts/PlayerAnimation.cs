using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float drawWeaponSpeed;
    [SerializeField] float delayBeforeWeaponDown = 3;
    Coroutine currentFadeRoutine;
    GameObject weapons;
    void Awake()
    {
        GetComponent<Health>().OnDied += PlayerAnimator_OnDied;
        weapons = GameObject.Find("Weapons");
    }

    private void PlayerAnimator_OnDied()
    {
        animator.SetTrigger("Die");
        Destroy(GetComponent<PlayerMovement>().characterController);
        this.enabled = false;
        weapons.SetActive(false);
    }

    

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(currentFadeRoutine != null)
                StopCoroutine(currentFadeRoutine);

            currentFadeRoutine = StartCoroutine(FadeToShootingLayer());
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            if (currentFadeRoutine != null)
                StopCoroutine(currentFadeRoutine);

            currentFadeRoutine = StartCoroutine(FadeFromShootingLayer());
        }
            
    }

    IEnumerator FadeFromShootingLayer()
    {
        yield return currentFadeRoutine;

        yield return new WaitForSeconds(delayBeforeWeaponDown);

        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;

        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight -= Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;
        }

        animator.SetLayerWeight(1, 0);
    }

    IEnumerator FadeToShootingLayer()
    {
        float currentWeight = animator.GetLayerWeight(1);
        float elapsed = 0;

        while(elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight += Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeight);
            yield return null;
        }

        animator.SetLayerWeight(1, 1);
    }
}
