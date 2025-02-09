using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
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