using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGunBullet : MonoBehaviour
{
    [SerializeField] private float bulletLifeTime = 5f;

    private void Update()
    {
        StartCoroutine(DestroyBullet());
    }
    

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
