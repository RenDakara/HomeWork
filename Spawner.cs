using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _coinSpawnPoint;

    private void Start()
    {
       foreach (Transform spawnPoint in _coinSpawnPoint)
        {
            Instantiate(_coin, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
