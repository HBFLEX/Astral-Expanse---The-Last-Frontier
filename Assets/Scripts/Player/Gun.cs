using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private SpriteRenderer gun;
    private PlayerController _playerController;
    private bool _isFacingLeft = true;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        FlipGun();
    }

    private void FlipGun()
    {
        if (IsPlayerFacingLeft())
        {
            gun.flipX = false;
        }
        else
        {
            gun.flipX = true;
        }
    }

    private bool IsPlayerFacingLeft()
    {
        if (_playerController._movement.x > 0.1)
        {
            _isFacingLeft = false;
        }
        else if(_playerController._movement.x < -0.1)
        {
            _isFacingLeft = true;
        }

        return _isFacingLeft;
    }
}
