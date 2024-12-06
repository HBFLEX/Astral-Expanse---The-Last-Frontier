using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : Singleton<Pickup>
{
    private Transform _playerPos;
    public bool isPlayerCloseToPickup = false;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

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
        }
        else
        {
            isPlayerCloseToPickup = false;
        }
    }

    public void Pick()
    {
        Destroy(gameObject);
        isPlayerCloseToPickup = false;
        Debug.Log("Signal Receiver acquired. Congratulations you have won the game");
        SceneManager.LoadScene(4); // go to the final scene
    }
}
