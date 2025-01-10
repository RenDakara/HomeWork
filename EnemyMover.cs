using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Vector3 _movementDirection;

    public void SetMovementDirection(Vector3 movementDirection)
    {
        _movementDirection = movementDirection;
    }

    private void Update()
    { 
        transform.Translate(_movementDirection * Time.deltaTime);
    }

}
