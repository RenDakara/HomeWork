using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _coinSpawnPosition;

    private void Start()
    {
       foreach (Transform spawnPoint in _coinSpawnPosition)
        {
           Coin coin = Instantiate(_coin, spawnPoint.position, spawnPoint.rotation);

            coin.OnCoinCollected += HandleCoinCollected;
        }
    }

    private void HandleCoinCollected(Coin coin)
    {
        Destroy(coin.gameObject);
    }
}

