using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 3f;

    private GroundChecker _check;
    private InputService _inputService;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _inputService = GetComponent<InputService>();
        _check = GetComponent<GroundChecker>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (_inputService.GetJumpInput() && _check.IsOnGround())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}

