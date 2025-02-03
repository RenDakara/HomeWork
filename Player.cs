using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private bool _isRunning;
    private SpriteRenderer _renderer;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0)
        {
            _isRunning = true;
            Run();
        }
        else
        {
            _isRunning = false;
        }

        _animator.SetBool("IsRunning", _isRunning);
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);
        _renderer.flipX = dir.x < 0.0f;
    }
}