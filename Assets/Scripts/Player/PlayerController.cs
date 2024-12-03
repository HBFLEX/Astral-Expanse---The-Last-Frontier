using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerController : Singleton<PlayerController>
{
    private PlayerControls _playerControls;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;
    
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private Transform muzzleFlash;
    [SerializeField] private Transform gunTip;
    
    [SerializeField] private float speed = 3f;
    public Vector2 _movement;
    [SerializeField] private bool hasGun = true;
    
    private bool _isDashing = false;
    [SerializeField] private float dashSpeed = 2f;
    [SerializeField] private float dashTime = 0.3f;

    [SerializeField] private Transform bulletShootingSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    
    [SerializeField] private float bulletSpeed = 4f;
    private Vector2 _lastFacingDirection;
    
    public bool isFacingLeft = true;
    
    private void OnEnable()
    {
        _playerControls.Enable();
    }
    
    protected override void Awake()
    {
        base.Awake();
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
        _lastFacingDirection = isFacingLeft ? Vector2.left : Vector2.right;
        
        FlashMuzzleEffect();
        GameObject bulletPrefabObj = Instantiate(bulletPrefab, bulletShootingSpawnPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bulletPrefabObj.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.AddForce(_lastFacingDirection * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    private void FlashMuzzleEffect()
    {
        if (muzzleFlash != null)
        {
            GameObject muzzleFlashObj = Instantiate(muzzleFlash.gameObject, gunTip.position, Quaternion.identity);
            float size = Random.Range(0.1f, 0.02f);
            muzzleFlashObj.transform.localScale = new Vector3(size, size, size);
            muzzleFlashObj.transform.rotation = isFacingLeft ? Quaternion.Euler(0f, 0f, 0f) : Quaternion.Euler(0f, 180f,0f);
            if (muzzleFlashObj != null)
            {
                Destroy(muzzleFlashObj, 0.05f);
            }
        }
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
            isFacingLeft = false;
           _sr.flipX = true;
        }
        else if(_movement.x < -0.1)
        {
            isFacingLeft = true;
            _sr.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}
