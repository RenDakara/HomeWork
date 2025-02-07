using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform[] _wayPoints;

    private bool _movingRight = true;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, true);

        if (_movingRight)
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);

            if(transform.position.x >= _wayPoints[1].position.x)
            {
                _movingRight = false;
                _spriteRenderer.flipX = true;
            }
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
            
            if(transform.position.x <= _wayPoints[0].position.x)
            {
                _movingRight = true;
                _spriteRenderer.flipX = false;
            }
        }
    }
}
