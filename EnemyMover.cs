using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Transform _target;
    private float _arrivalDistance = 0.5f;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 targetPosition = _target.position;
            Vector3 movementDirection = (targetPosition - transform.position).normalized;
            transform.Translate(movementDirection * _movementSpeed * Time.deltaTime);
            Vector3 position = transform.position;
            position.y = 0;
            transform.position = position;

            if (Vector3.Distance(transform.position, targetPosition) < _arrivalDistance)
            {
                Destroy(gameObject); // ”ничтожение врага, когда он достиг цели
            }
        }

    }
}