using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isRunning;
    private Animator _animator;
    private Movement _movement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        _movement.Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0)
        {
            _isRunning = true;
            _movement.Run();
        }
        else
        {
            _isRunning = false;
        }

        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, _isRunning);
    }
}
