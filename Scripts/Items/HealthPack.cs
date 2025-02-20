using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public event Action<HealthPack> OnHealthPackCollected;

    public void Collect()
    {
        OnHealthPackCollected?.Invoke(this);
        Destroy(gameObject);
    }
}
