using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        GetComponent<Health>().OnTookHit += ZombieAnimator_OnTookHit;
        GetComponent<Health>().OnDied += ZombieAnimator_OnDied;
        GetComponent<ZombieAttack>().OnAttack += ZombieAttack_OnAttack;
        GetComponent<ZombieAttack>().OnEat += ZombieAttack_OnEat;

    }

    private void ZombieAttack_OnEat()
    {
        animator.SetTrigger("Eat");
    }

    private void ZombieAttack_OnAttack()
    {
        animator.SetInteger("AttackId", UnityEngine.Random.Range(1, 3));
        animator.SetTrigger("Attack");
    }

    private void ZombieAnimator_OnDied()
    {
        animator.SetTrigger("Die");
    }

    private void ZombieAnimator_OnTookHit()
    {
        animator.SetTrigger("Hit");
    }
}
