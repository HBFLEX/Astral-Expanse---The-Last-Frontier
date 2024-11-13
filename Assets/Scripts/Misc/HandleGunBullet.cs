using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGunBullet : MonoBehaviour
{
    [SerializeField] private float bulletLifeTime = 4f;
    [SerializeField] private int enemyBulletDamageAmount = 10;
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GameObject.FindObjectOfType<EnemyHealth>();
    }

    private void Update()
    {
        StartCoroutine(DestroyBullet());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != null)
        {
            Destroy(gameObject);
            if(other.gameObject.CompareTag("Enemy") && _enemyHealth != null)
            {
                _enemyHealth.TakeDamage(enemyBulletDamageAmount);
            }
        }
    }


    private IEnumerator DestroyBullet()
    {
        if (gameObject)
        {
            yield return new WaitForSeconds(bulletLifeTime);
            Destroy(gameObject);
        }
    }
}
