using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    private bool _movingRight = true;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        _animator.SetBool("IsRunning", true);

        if (_movingRight)
        {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);

            if(transform.position.x >= _secondPoint.position.x)
            {
                _movingRight = false;
                _spriteRenderer.flipX = true;
            }
        }
        else
        {
            _rb.velocity = new Vector2(-_speed, _rb.velocity.y);
            
            if(transform.position.x <= _firstPoint.position.x)
            {
                _movingRight = true;
                _spriteRenderer.flipX = false;
            }
        }
    }
}
