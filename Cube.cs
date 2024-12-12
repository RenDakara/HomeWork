using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    static private float _splitChance = 10; // Уважаемый ментор, я помню, что статика это ужасно плохо, но я в упор не понимаю, почему у меня после первого деления переменная замирает в значении. Помогите..
    private float _chanceDivider = 2; 
    private CubeSpawner _cubeSpawner;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _cubeSpawner = GetComponent<CubeSpawner>();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    if (_cubeSpawner != null)
                    {
                        if (GetSpawnChance())
                        {
                            _cubeSpawner.CreateCubes(transform.position);
                            _splitChance /= _chanceDivider;
                            Destroy(gameObject);
                        }     
                        
                            Destroy(gameObject);
                    }
                }
            }
        }
    }

    private bool GetSpawnChance()
    {
        int randomNumber = UnityEngine.Random.Range(1, 9);

        return randomNumber <= _splitChance;
    }
}
