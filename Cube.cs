using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Raycast))]
[RequireComponent (typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Raycast _raycast;

    public float _splitChance = 10f;
    public Rigidbody Rigidbody { get; private set; }

    public event Action<Cube> OnCubeClicked;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _raycast = GetComponent<Raycast>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_raycast.CheckHit())
        {
            if (GetSpawnChance())
            {
                OnCubeClicked?.Invoke(this);
            }

            Destroy(gameObject);
        }
    }

    private bool GetSpawnChance()
    {
        int minNumber = 1;
        int maxNumber = 9;
        int randomNumber = UnityEngine.Random.Range(minNumber, maxNumber);

        return randomNumber <= _splitChance;
    }

    public void ChangeCubeColor()
    {
        _renderer.material.color = UnityEngine.Random.ColorHSV();
    }
}
