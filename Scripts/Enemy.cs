using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform[] _wayPoints;

    private bool _isMovingRight = true;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, true);

        if (_isMovingRight)
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);

            if(transform.position.x >= _wayPoints[1].position.x)
            {
                _isMovingRight = false;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
            
            if(transform.position.x <= _wayPoints[0].position.x)
            {
                _isMovingRight = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}

