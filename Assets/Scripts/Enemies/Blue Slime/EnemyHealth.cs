using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private int health = 50;
    private int _startHealth;

    private void Awake()
    {
        _startHealth = health;
    }

    public void TakeDamage(int damageAmount)
    {
        DetectDeath();
        _startHealth -= damageAmount;
    }

    private void DetectDeath()
    {
        if (_startHealth <= 0)
        {
            GameObject deathVFXPrefabClone = Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(deathVFXPrefabClone, 0.8f);
        }
    }
}
