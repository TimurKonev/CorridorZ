using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;

    public int currentHealth { get; private set; }

    public event Action OnTookHit = delegate { };
    public event Action OnDied = delegate { };
    public event Action<int, int> OnHealthChanged = delegate { };


    void OnEnable()
    {
        currentHealth = health;
    }

    public void TakeHit(int damage)
    {
        if (currentHealth <= 0)
            return;

        ModifyHealth(-damage);

        if (currentHealth > 0)
        {
            OnTookHit();
        }
        else
        {
            OnDied();
        }
    }

    void ModifyHealth(int amount)
    {
        currentHealth += amount;
        OnHealthChanged(currentHealth, health);
    }
}
