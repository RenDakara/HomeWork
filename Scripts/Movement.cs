using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 3f;

    private Rigidbody2D _rigidbody;
    private InputService _inputService;
    private bool _isRunning;
    private Animator _animator;
    private GroundCheck _check;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _check = GetComponent<GroundCheck>();
        _animator = GetComponent<Animator>();
        _inputService = GetComponent<InputService>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Run()
    {
        float horizontalInput = _inputService.GetHorizontalInput();

        if (horizontalInput != 0f)
        {
            _isRunning = true;

            Vector3 dir = transform.right * horizontalInput;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);
            _renderer.flipX = dir.x < 0.0f;
        }
        else
        {
            _isRunning = false;
        }

        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, _isRunning);
    }

    public void Jump()
    {     
        if (_inputService.GetJumpInput() && _check.IsOnGround())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}