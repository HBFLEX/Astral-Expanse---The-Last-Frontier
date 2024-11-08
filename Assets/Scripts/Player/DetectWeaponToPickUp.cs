using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetectWeaponToPickUp : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject pickUpTextObj;
    private TextMeshProUGUI _pickUpText;
    private PlayerControls _playerControls;
    private bool _isCloseToPickUp = false;
    private bool _isWeaponPicked = false;
    
    private void Awake()
    {
        _playerControls = new PlayerControls();
        _pickUpText = pickUpTextObj.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _playerControls.Player.Interact.performed += _ => PickupWeapon();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Update()
    {
        DetectWeapon();
    }

    private void DetectWeapon()
    {
        if (weapons.Length > 0)
        {
            Vector2 distance = transform.position - weapons[0].transform.position;
            if (distance.magnitude > -1.3f && distance.magnitude < 1.3f && !_isWeaponPicked)
            {
                _isCloseToPickUp = true;
                _pickUpText.text = "Press [E] to interact";
                pickUpTextObj.gameObject.SetActive(true);
            }
            else
            {
                _isCloseToPickUp = false;
                pickUpTextObj.gameObject.SetActive(false);
            }
        }
    }

    private void PickupWeapon()
    {
        if (_isCloseToPickUp)
        {
            weapons[0].transform.gameObject.SetActive(false);
            _isWeaponPicked = true;
            _pickUpText.text = "Weapon picked";
            Invoke(nameof(HidePickUpText), 2f);
        }
    }

    private void HidePickUpText()
    {
        pickUpTextObj.gameObject.SetActive(false);
    }
}
