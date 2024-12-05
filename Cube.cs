using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class Cube : MonoBehaviour
{
    private int _successNumber = 10;
    private float _scaleDivide = 2f;
    private Renderer _renderer;
    private bool _isSplit = true;

    public event Action CubeSpawned;
    public event Action Explosion;

    private void OnMouseDown()
    {
        Destroy(gameObject);

        if (GetSpawnChance())
        {
            DecreaseChances();
            CubeSpawned?.Invoke();
        }
        else
        {
            Explosion?.Invoke();
        }
    }

    private void DecreaseChances()
    {
        gameObject.transform.localScale /= _scaleDivide;
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private bool GetSpawnChance()
    {
        int randomNumber = UnityEngine.Random.Range(1, 9);

        if (_successNumber < randomNumber)
        {
            _isSplit = false;
        }

        _successNumber--;
        return _isSplit;
    }
}
