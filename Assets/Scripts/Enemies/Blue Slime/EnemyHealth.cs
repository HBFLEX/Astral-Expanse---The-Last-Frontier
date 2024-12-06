using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private int health = 50;
    [SerializeField] private float knockBackThrust = 15f;
    private int _startHealth;
    
    private Knockback knockback;
    private Flash flash;
    
    private PlaySFX playSFX; 

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        playSFX = GetComponent<PlaySFX>();
    }

    private void Start()
    {
        _startHealth = health;
    }

    public void TakeDamage(int damageAmount)
    {
        _startHealth -= damageAmount;
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }
    
    private IEnumerator CheckDetectDeathRoutine() {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (_startHealth <= 0)
        {
            if (playSFX)
            {
                playSFX.PlaySound();
            }
            GameObject deathVFXPrefabClone = Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(deathVFXPrefabClone, 0.8f);
        }
    }
}
