using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMover _movement;
    private Jumper _jumper;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _movement = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
    }

    private void Update()
    {
        _health.ShowInfo();
        _movement.Run();
    }

    private void FixedUpdate()
    {
        _jumper.Jump();
    }

    public void TakeDamage(float damage)
    {
      _health.TakeDamage(damage);
    }

    public void Heal(float amount)
    {
        _health.Heal(amount);
    }
}