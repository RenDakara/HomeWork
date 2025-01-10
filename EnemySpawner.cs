using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private float _spawnTime = 2f;
    private float _time = 0f;
    private float _spawnRadius = 5f;
    private float _spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _time, _spawnTime);
    }

    private void Spawn()
    {
        float randomX = Random.Range(-_spawnRadius, _spawnRadius);
        float randomZ = Random.Range(-_spawnRadius, _spawnRadius);

        Vector3 spawnPosition = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        GameObject enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);   
        
        Vector3 movementDirection = (transform.position - spawnPosition).normalized;
        enemy.GetComponent<EnemyMover>().SetMovementDirection(movementDirection);
    }

}
