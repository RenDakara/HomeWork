using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _layerMask;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    public void Run()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 dir = transform.right * horizontalInput;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);
        _renderer.flipX = dir.x < 0.0f;
    }

    public void Jump()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _layerMask);

        if (Input.GetButtonDown("Jump") && _isGrounded)
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
}
