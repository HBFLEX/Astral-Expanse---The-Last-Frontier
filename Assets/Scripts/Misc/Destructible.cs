using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject  destroyVFXPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if(GetComponent<PickupSpawner>() != null)
            {
                GetComponent<PickupSpawner>().SpawnPickup();
            }
            Destroy(gameObject);
            GameObject destroyVFXPrefabClone = Instantiate(destroyVFXPrefab, transform.position, Quaternion.identity);
            Destroy(destroyVFXPrefabClone, 0.6f);
        }
    }
}
