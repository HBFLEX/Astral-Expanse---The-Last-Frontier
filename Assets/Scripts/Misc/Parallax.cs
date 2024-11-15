using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Camera _cam;
    private Vector2 _startPos;
    private Vector2 travel => (Vector2)_cam.transform.position - _startPos;
    [SerializeField] private float parallaxOffset = -0.4f;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void Start()
    {
        _startPos = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = _startPos + (travel * parallaxOffset);
    }
}
