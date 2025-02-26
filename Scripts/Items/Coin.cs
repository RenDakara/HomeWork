using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> OnCoinCollected;

    public void Collect()
    {
        OnCoinCollected?.Invoke(this);
    }
}