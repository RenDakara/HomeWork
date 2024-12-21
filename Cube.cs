using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Explosion))]

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Explosion _explosion;
    private float _chancesDivider = 2;
    private float _splitChance = 10f;

    public Rigidbody Rigidbody { get; private set; }

    public event Action<Cube> Clicked;

    private void OnMouseDown()
    {
        if (GetSpawnChance())
        {
            Clicked?.Invoke(this);
            DecreaseChances();
        }
        else
        {
            _explosion.ExplodeAll();
        }

        Destroy(gameObject);
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
        _explosion = GetComponent<Explosion>();
    }

    private bool GetSpawnChance()
    {
        float minNumber = 5f;
        float maxNumber = 11f;
        float randomNumber = UnityEngine.Random.Range(minNumber, maxNumber);

        return randomNumber <= _splitChance;
    }

    private void DecreaseChances()
    {
        _splitChance /= _chancesDivider;
    }

    public void ChangeCubeColor()
    {
        _renderer.material.color = UnityEngine.Random.ColorHSV();
    }

    public Vector3 GetSize()
    {
        return transform.localScale;
    }
}
