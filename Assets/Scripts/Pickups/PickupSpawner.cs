using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;
    public void SpawnPickup()
    {
        if (pickupPrefab != null)
        {
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        }
    }
}
