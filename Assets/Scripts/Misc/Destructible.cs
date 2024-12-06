using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject  destroyVFXPrefab;
    [SerializeField] private float destructionDelay = 0.5f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if(GetComponent<PickupSpawner>() != null)
            {
                GetComponent<PickupSpawner>().SpawnPickup();
            }

            if (GetComponent<PlaySFX>() != null)
            {
                GetComponent<PlaySFX>().PlaySound();
            }
            
            GameObject destroyVFXPrefabClone = Instantiate(destroyVFXPrefab, transform.position, Quaternion.identity);
            Destroy(destroyVFXPrefabClone, 0.6f);
            
            Destroy(gameObject, destructionDelay);
        }
    }
}
