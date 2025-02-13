using UnityEngine;

public class Player : MonoBehaviour
{
    private Mover _movement;

    private void Awake()
    {
        _movement = GetComponent<Mover>();
    }

    private void Update()
    {
        _movement.Run();
    }

    private void FixedUpdate()
    {
        _movement.Jump();
    }
}