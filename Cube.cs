using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public float _splitChance = 10f;

    public event Action<Cube> OnCubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    if (GetSpawnChance())
                    {
                        OnCubeClicked?.Invoke(this);
                    }

                    Destroy(gameObject);
                }
            }
        }
    }

    private bool GetSpawnChance()
    {
        int randomNumber = UnityEngine.Random.Range(1, 9);

        return randomNumber <= _splitChance;
    }

    public void ChangeCubeColor()
    {
        Renderer rd = GetComponent<Renderer>();
        rd.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }
}
