using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private HealthPack _healthPack;
    [SerializeField] private List<Transform> _coinSpawnPosition;
    [SerializeField] private List<Transform> _healthSpawnPosition;

    private void Start()
    {
        SpawnCoin();
        SpawnHealthPack();
    }

    private void HandleCoinCollected(Coin coin)
    {
        Destroy(coin.gameObject);
    }

    private void HandleHealthPackCollected(HealthPack healthPack)
    {
        Destroy(healthPack.gameObject);
    }

    private void SpawnCoin()
    {
        foreach (Transform spawnPoint in _coinSpawnPosition)
        {
            Coin coin = Instantiate(_coin, spawnPoint.position, spawnPoint.rotation);

            coin.OnCoinCollected += HandleCoinCollected;
        }
    }

    private void SpawnHealthPack()
    {
        foreach (Transform spawnPoint in _healthSpawnPosition)
        {
            HealthPack healthPack = Instantiate(_healthPack, spawnPoint.position, spawnPoint.rotation);

            healthPack.OnHealthPackCollected += HandleHealthPackCollected;
        }
    }
}

