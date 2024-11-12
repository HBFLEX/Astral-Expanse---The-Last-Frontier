using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Walking,
    }

    private Rigidbody2D _rb;
    private EnemyPathFinding _pathFinding;
    private State _state;
    [SerializeField] private float findAnotherPathDecisionTime = 2.3f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pathFinding = GetComponent<EnemyPathFinding>();
        _state = State.Walking;
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (_state == State.Walking)
        {
            Vector2 direction = FindPath();
            _pathFinding.Move(direction);
            yield return new WaitForSeconds(findAnotherPathDecisionTime);
        }
    }

    private Vector2 FindPath()
    {
        return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(1.0f, -1.0f));
    }
}
