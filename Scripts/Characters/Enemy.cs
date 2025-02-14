using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CharacterAnimator _enemyRenderer;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _enemyRenderer = GetComponent<CharacterAnimator>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        _enemyRenderer.MakeAnimation(true);
        _enemyMover.MoveEnemy();
    }
}

