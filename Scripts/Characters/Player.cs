using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 10f;

    private PlayerMover _movement;
    private Jumper _jumper;

    public void TakeDamage(float damage)
    {
        _playerHealth -= damage;
        if(_playerHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        _playerHealth += amount;
        _playerHealth = Mathf.Min( _playerHealth, 10f);
    }

    private void Die()
    {
            Destroy(this.gameObject);
    }

    private void Awake()
    {
        _movement = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
    }

    private void Update()
    {
        Debug.Log(_playerHealth);
        _movement.Run();
    }

    private void FixedUpdate()
    {
        _jumper.Jump();
    }
}