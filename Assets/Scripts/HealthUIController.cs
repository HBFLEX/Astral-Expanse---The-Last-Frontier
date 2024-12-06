using System;
using TMPro;
using UnityEngine;

public class HealthUIController : Singleton<HealthUIController>
{
    [SerializeField] private TextMeshProUGUI healthText;
    private PlayerHealth playerHealth;


    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        healthText.text = playerHealth.maxHealth.ToString();
    }

    private void Update()
    {
        healthText.text = playerHealth.currentHealth.ToString();
    }
}
