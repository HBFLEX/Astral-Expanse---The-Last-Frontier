using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Transform _playerPos;
    public bool isPlayerCloseToPickup = false;

    private void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 currentDistance = _playerPos.position - transform.position;
        if (currentDistance.magnitude < 0.8f)
        {
            isPlayerCloseToPickup = true;
            Debug.Log("Press E to pickup");
        }
        else
        {
            isPlayerCloseToPickup = false;
        }
    }

    public void Pick()
    {
        Destroy(gameObject);
        Debug.Log("Signal Receiver acquired. Congratulations you have won the game");
    }
}
