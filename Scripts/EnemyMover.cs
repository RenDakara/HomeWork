using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform[] _wayPoints;

    private bool _isMovingRight = true;
    private Rigidbody2D _rigidbody;
    private int _firstPoint = 0;
    private int _lastPoint = 1;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveEnemy()
    {
        if (_isMovingRight)
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);

            if (transform.position.x >= _wayPoints[_lastPoint].position.x)
            {
                _isMovingRight = false;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);

            if (transform.position.x <= _wayPoints[_firstPoint].position.x)
            {
                _isMovingRight = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
