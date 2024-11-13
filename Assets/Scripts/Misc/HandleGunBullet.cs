using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGunBullet : MonoBehaviour
{
    [SerializeField] private float bulletLifeTime = 4f;

    private void Update()
    {
        StartCoroutine(DestroyBullet());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject != null)
        {
            Destroy(gameObject);
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
