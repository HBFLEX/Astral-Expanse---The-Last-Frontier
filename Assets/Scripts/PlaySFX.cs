using System;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {

        audioSource.volume = 0.5f;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
