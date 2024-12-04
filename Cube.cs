using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    static private int successNumber = 10;
    private float scaleDivide = 2f;
    private float chanceDivide = 2f;
    private Renderer renderer;
    private bool isSplit = true;

    private void OnMouseDown()
    {
        if (GetSpawnChance())
        {
            Destroy(gameObject);
            ChancesDecrease();
            SpawnCubes();
        }
        else
        {
            Destroy(gameObject);
            Explode();
        }
    }

    private int GetRandomCubes()
    {
        int min = 2;
        int max = 6;
        int randomCubes = Random.Range(min, max);
        return randomCubes;
    }

    private void ChancesDecrease()
    {
        gameObject.transform.localScale /= scaleDivide;
        renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    private void SpawnCubes()
    {
        for (int i = 0; i < GetRandomCubes(); i++)
            Instantiate(gameObject, gameObject.transform.localPosition, Quaternion.identity);
    }

    private bool GetSpawnChance()
    {
        int randomNumber = Random.Range(1, 9);

        if (successNumber < randomNumber)
        {
            isSplit = false;
        }

        successNumber--;
        return isSplit;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObjects in GetExplodableObjects())
            explodableObjects.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
