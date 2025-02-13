using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerRenderer _playerRenderer;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _playerRenderer = GetComponent<PlayerRenderer>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        _playerRenderer.GetAnimation(true);
        _enemyMover.MoveEnemy();
    }
}

