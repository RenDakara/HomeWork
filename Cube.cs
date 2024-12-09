using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1f; // Начинаем с 100%
    private float _splitChanceDivider = 2f;
  
    public event Action OnClickSpawning;
    public event Action OnClickExploding;

    private void OnMouseDown()
    {
        if (CheckChances())
        {
            OnClickSpawning?.Invoke();
        }
        else
        {
            OnClickExploding?.Invoke();
        }

        Destroy(gameObject); 
    }

    private bool CheckChances()
    {
        float checkNumber = UnityEngine.Random.Range(0f, 1f); 
        bool isSplit = checkNumber < _splitChance;

        if (isSplit)
        {
            _splitChance /= _splitChanceDivider; 
        }

        return isSplit;
    }
}
