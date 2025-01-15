using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyPoint _enemyPoint;
    private float _spawnTime = 2f;
    private float _time = 0f;
    private float _spawnRadius = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _time, _spawnTime);
    }

    private void Spawn()
    {
        float randomX = Random.Range(-_spawnRadius, _spawnRadius);
        float randomZ = Random.Range(-_spawnRadius, _spawnRadius);
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Enemy newEnemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);
        newEnemy.GetComponent<EnemyMover>().SetTarget(_enemyPoint.transform);
    }
}