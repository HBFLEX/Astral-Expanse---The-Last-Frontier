using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGunBullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float bulletLifeTime = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        StartCoroutine(DestroyBullet());
    }

    private void FixedUpdate()
    {
        _rb.AddForce(transform.parent.right * speed, ForceMode2D.Impulse);
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
