using System;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
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
        audioSource.PlayOneShot(clip);
    }
}
