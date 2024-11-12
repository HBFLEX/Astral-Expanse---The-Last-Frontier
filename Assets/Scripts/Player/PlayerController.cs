using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;
    [SerializeField] private TrailRenderer trailRenderer;
    
    [SerializeField] private float speed = 3f;
    public Vector2 _movement;
    [SerializeField] private bool hasGun = true;
    
    private bool _isDashing = false;
    [SerializeField] private float dashSpeed = 2f;
    [SerializeField] private float dashTime = 0.3f;

    [SerializeField] private Transform bulletShootingSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    private GameObject _bulletPrefabObj;
    
    private void OnEnable()
    {
        _playerControls.Enable();
    }
    
    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _rb = GetComponent <Rigidbody2D>();
        _animator = GetComponent <Animator>();
        _sr = GetComponent <SpriteRenderer>();
    }

    private void Start()
    {
        _playerControls.Player.Dash.performed += _ => Dash();
        _playerControls.Player.Shoot.performed += _ => Shoot();
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
        _rb.MovePosition(_rb.position + _movement * (speed * Time.fixedDeltaTime));
    }

    private void Dash()
    {
        if (!_isDashing)
        {
            _isDashing = true;
            speed *= dashSpeed;
            trailRenderer.emitting = true;
            StartCoroutine(EndDashRoutine());
        }
    }

    private void Shoot()
    {
        _bulletPrefabObj = Instantiate(bulletPrefab, bulletShootingSpawnPoint.position, Quaternion.identity);
        _bulletPrefabObj.transform.parent = bulletShootingSpawnPoint.parent;
    }

    private IEnumerator EndDashRoutine()
    {
        yield return new WaitForSeconds(dashTime);
        speed /= dashSpeed;
        trailRenderer.emitting = false;
        _isDashing = false;
    }

    private void GetPlayerInput()
    {
        // get the player input
        _movement = _playerControls.Player.Move.ReadValue<Vector2>();
        // animate running state
        
        _animator.SetBool("hasGun", hasGun); 
        _animator.SetFloat("MoveY", _movement.y);
        _animator.SetFloat("MoveX", _movement.x);
        
    }

    private void ChangePlayerDirectionOnAxis()
    {
        if (_movement.x > 0.1)
        {
           _sr.flipX = true;
        }
        else if(_movement.x < -0.1)
        {
            _sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}
