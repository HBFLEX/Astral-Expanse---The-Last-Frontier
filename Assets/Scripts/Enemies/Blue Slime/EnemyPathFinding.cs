using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveDir;
    [SerializeField] private float speed = 3f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveDir * (speed * Time.fixedDeltaTime));
    }

    public void Move(Vector2 dir)
    {
        _moveDir = dir;
    }
}
