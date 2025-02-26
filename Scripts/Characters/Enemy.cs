using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _detectionRange = 5f;

    private CharacterAnimator _enemyRenderer;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyRenderer = GetComponent<CharacterAnimator>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= _attackRange)
            {
                player.TakeDamage(_damage);
                _enemyRenderer.PlayRunningAnimation(false);
                _enemyRenderer.PlayAttackAnimation(true);
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            _enemyMover.ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        _enemyRenderer.PlayAttackAnimation(false);
        _enemyRenderer.PlayRunningAnimation(true);
        _enemyMover.Patrol();
    }

    private bool IsPlayerInRange()
    {
        return (_playerPosition.position - transform.position).sqrMagnitude <= _detectionRange * _detectionRange;
    }
}

