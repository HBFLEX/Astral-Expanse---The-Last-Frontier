using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Transform _playerPos;

    private void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerStay2D(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("CONGRATULATIONS YOU WON THE GAME!");
        }
    }

    private void Update()
    {
        Vector3 currentDistance = _playerPos.position - transform.position;
        if (currentDistance.magnitude < 0.8f)
        {
            Debug.Log("PICKUP SIGNAL RECEIVER");
        }
    }
}
