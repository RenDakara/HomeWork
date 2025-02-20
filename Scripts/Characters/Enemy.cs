using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private Transform _player;
    [SerializeField] private float _detectionRange = 5f;

    public event Action<Enemy> OnEnemyKilled;
    private CharacterAnimator _enemyRenderer;
    private EnemyMover _enemyMover;

    public void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= _attackRange)
            {
                player.TakeDamage(_damage);
            }
        }
    }

    private void Awake()
    {
        _enemyRenderer = GetComponent<CharacterAnimator>();
        _enemyMover = GetComponent<EnemyMover>();
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
        _enemyRenderer.MakeAnimation(true);
        _enemyMover.MoveEnemy();
    }

    private bool IsPlayerInRange()
    {
        return Vector2.Distance(transform.position, _player.position) <= _detectionRange;
    }
}

