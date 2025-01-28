using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody _rigidbody;
    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis(_horizontal);
        float verticalInput = Input.GetAxis(_vertical);

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        _rigidbody.MovePosition(transform.position +  movement * _speed * Time.deltaTime);
    }
}
