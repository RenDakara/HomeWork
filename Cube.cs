using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Raycast))]
[RequireComponent (typeof(Rigidbody))]
[RequireComponent(typeof(Explosion))]

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private Raycast _raycast;
    private Explosion _explosion;

    public float _splitChance = 5f;
    public Rigidbody Rigidbody { get; private set; }

    public event Action<Cube> OnCubeClicked;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _raycast = GetComponent<Raycast>();
        Rigidbody = GetComponent<Rigidbody>();
        _explosion = GetComponent<Explosion>();
    }

    private void Update()
    {
        if (_raycast.CheckHit())
        {
            if (GetSpawnChance())
            {
                OnCubeClicked?.Invoke(this);
            }
            else
            {
                _explosion.Explode();
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

    public Vector3 GetSize()
    {
        return transform.localScale;
    }
}
