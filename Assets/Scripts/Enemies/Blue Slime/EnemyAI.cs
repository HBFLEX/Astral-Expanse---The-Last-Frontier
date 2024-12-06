using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private MonoBehaviour enemyType;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private bool stopMovingWhileAttacking = false;
    
    private bool canAttack = true;

    
    private enum State
    {
        Roaming, 
        Attacking
    }

    private Rigidbody2D _rb;
    private EnemyPathFinding _pathFinding;
    private State _state;
    [SerializeField] private float findAnotherPathDecisionTime = 2.3f;
    private float timeRoaming = 0f;
    private Vector2 roamPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pathFinding = GetComponent<EnemyPathFinding>();
        _state = State.Roaming;
    }

    private void Start() {
        roamPosition = GetRoamingPosition();
    }
    
    private void Update() {
        MovementStateControl();
    }
    
    private void MovementStateControl() {
        switch (_state)
        {
            default:
            case State.Roaming:
                Roaming();
                break;

            case State.Attacking:
                Attacking();
                break;
        }
    }
    
    private void Roaming() {
        timeRoaming += Time.deltaTime;

        _pathFinding.Move(roamPosition);

        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < attackRange) {
            _state = State.Attacking;
        }

        if (timeRoaming > roamChangeDirFloat) {
            roamPosition = GetRoamingPosition();
        }
    }

    private void Attacking() {
        if (Vector2.Distance(transform.position, PlayerController.Instance.transform.position) > attackRange)
        {
            _state = State.Roaming;
        }

        if (attackRange != 0 && canAttack) {

            canAttack = false;
            if (enemyType != null)
            {
                (enemyType as IEnemy).Attack();
            }

            if (stopMovingWhileAttacking) {
                _pathFinding.StopMoving();
            } else {
                _pathFinding.Move(roamPosition);
            }

            StartCoroutine(AttackCooldownRoutine());
        }
    }

    private IEnumerator AttackCooldownRoutine() {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }


    // private IEnumerator Move()
    // {
    //     while (_state == State.Roaming)
    //     {
    //         Vector2 direction = FindPath();
    //         _pathFinding.Move(direction);
    //         yield return new WaitForSeconds(findAnotherPathDecisionTime);
    //     }
    // }

    private Vector2 GetRoamingPosition() {
        timeRoaming = 0f;
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
