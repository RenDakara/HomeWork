using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 3f;

    private Rigidbody2D _rigidbody;
    private InputService _inputService;
    private bool _isRunning;
    private PlayerRenderer _playerRenderer;
    private GroundCheck _check;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _check = GetComponent<GroundCheck>();
        _playerRenderer = GetComponent<PlayerRenderer>();
        _inputService = GetComponent<InputService>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Run()
    {
        float horizontalInput = _inputService.GetHorizontalInput();

        if (horizontalInput != 0f)
        {
            Vector2 direction = new Vector2(horizontalInput, 0f).normalized;
            _rigidbody.velocity = direction * _speed;
            _renderer.flipX = direction.x < 0.0f;
            _isRunning = true;
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
            _isRunning = false;
        }

        _playerRenderer.GetAnimation(_isRunning);
    }

    public void Jump()
    {     
        if (_inputService.GetJumpInput() && _check.IsOnGround())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}