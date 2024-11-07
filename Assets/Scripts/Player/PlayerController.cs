using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;
    [SerializeField] private float _speed = 5f;
    private Vector2 _movement;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rb = GetComponent <Rigidbody2D>();
        _animator = GetComponent <Animator>();
        _sr = GetComponent <SpriteRenderer>();
    }

    private void Start()
    {
        _playerControls.Enable();
    }

    private void Update()
    {
        GetPlayerInput();
        FixPlayerSize();
        ChangePlayerDirectionOnAxis();
    }

    private void FixPlayerSize()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void MovePlayer()
    {
        _rb.MovePosition(_rb.position + _movement * (_speed * Time.fixedDeltaTime));
    }

    private void GetPlayerInput()
    {
        // get the player input
        _movement = _playerControls.Player.Move.ReadValue<Vector2>();
        // animate running state
        _animator.SetFloat("MoveX", _movement.x);
        _animator.SetFloat("MoveY", _movement.y);
    }

    private void ChangePlayerDirectionOnAxis()
    {
        if (_movement.x > 0.1)
        {
           _sr.flipX = true; 
        }
        else
        {
            _sr.flipX = false;
        }
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
