using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Transparency : MonoBehaviour
{
    private Tilemap _tilemap;
    
    // fade effect options
    [Range(0, 1f)]
    [SerializeField] private float transparencyAmount = 0.8f;
    [SerializeField] private float durationTime = 0.4f;

    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeRoutine(_tilemap, _tilemap.color.a, transparencyAmount, durationTime));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeRoutine(_tilemap, _tilemap.color.a, 1f, durationTime));
        }
    }

    private IEnumerator FadeRoutine(Tilemap tilemap, float startValue, float endValue, float fadeTime)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / fadeTime);
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, newAlpha);
            yield return null;
        }
    }
}
