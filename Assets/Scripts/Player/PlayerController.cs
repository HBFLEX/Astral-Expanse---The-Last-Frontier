using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 5f;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rb = GetComponent <Rigidbody2D>();
    }

    private void Start()
    {
        _playerControls.Enable();
    }

    private void MovePlayer()
    {
        Vector2 movement = _playerControls.Player.Move.ReadValue<Vector2>();
        _rb.MovePosition(_rb.position + movement * (_speed * Time.fixedDeltaTime));
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
