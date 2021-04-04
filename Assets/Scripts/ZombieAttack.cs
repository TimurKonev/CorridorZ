using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] float delayBetweenAttacks = 1.5f;
    [SerializeField] float maximumAttackRange = 1.5f;
    [SerializeField] float maximumEatingRange = 1f;
    [SerializeField] float delayBetweenAnimationAndDamage = 0.25f;


    float attackTimer;
    int damage = 1;
    Health playerHealth;
    Health zombieHealth;

    public event Action OnAttack = delegate { };
    public event Action OnEat = delegate { };


    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
        zombieHealth = GetComponent<Health>();
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        if(CanAttack())
        {
            attackTimer = 0;
            Attack();
        }
        
        if(CanEat())
        {
            Eat();
        }
    }



    bool CanAttack()
    {
        return attackTimer >= delayBetweenAttacks 
            && Vector3.Distance(transform.position, playerHealth.transform.position) <= maximumAttackRange 
            && zombieHealth.currentHealth > 0 
            && playerHealth.currentHealth > 0;
    }
    void Attack()
    {
        OnAttack();

        StartCoroutine(DealDamageAfterDelay());
    }
    bool CanEat()
    {
        return playerHealth.currentHealth <= 0 && Vector3.Distance(transform.position, playerHealth.transform.position) <= maximumEatingRange;
    }
    void Eat()
    {
        OnEat();
    }

    private IEnumerator DealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationAndDamage);
        playerHealth.TakeHit(damage);
    }
}
