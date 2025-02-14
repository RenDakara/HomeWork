using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMover _movement;
    private Jumper _jumper;

    private void Awake()
    {
        _movement = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
    }

    private void Update()
    {
        _movement.Run();
    }

    private void FixedUpdate()
    {
        _jumper.Jump();
    }
}